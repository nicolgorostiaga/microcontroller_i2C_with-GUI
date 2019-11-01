#include <24FV16KM202.h>

#FUSES FRC_PLL

#use delay(clock = 32MHZ, internal = 8MHZ)
#USE RS232(UART2, BAUD = 115200, PARITY = N, BITS = 8, STOP = 1, TIMEOUT =500))

#define EEPROM_SDA PIN_B2
#define EEPROM_SCL PIN_B3
#define EEPROM_ADDRESS int16
#use i2c(MASTER, I2C2, SLOW, FORCE_HW)
//Ascii values are displayed and converted to decimal
BYTE gethex1(){

   char digit=0;              //variable for the value
  do{
       if(kbhit()){
         digit = getc();     //ascii value pushed key from keyboard
         putc(digit);        //display GUI
       }
    delay_ms(1);              // delay by 1 ms
    } while(digit == 0);
  //covert ascii to decimal for values less than 10
  if(digit<='9') 
     return(digit-'0');
 //covert ascii to decimal for values greater than 10
 else
     return((toupper(digit)-'A')+10);
  }
                     
// Process one byte of data                  
BYTE gethex() {
    unsigned int8 lo,hi;
     hi = gethex1();          //the upper half of the byte
     lo = gethex1();          //the lower half of the byte
 
 if(lo==0xdd)
          return(hi);         //return upper half
 else
      return( hi*16 + lo );   //return the whole byte

}

//Set Pin SDA and SCL to the input mode
void init_ext_eeprom() {
 output_float(EEPROM_SCL); 
 output_float(EEPROM_SDA);
}

//Start, ready, and stop the device
BOOLEAN ext_eeprom_ready() {
 int1 ack;
 i2c_start(); // If the write command is acknowledged,
 ack = i2c_write(0xa0); // the device is ready.
 i2c_stop(); 

 return !ack;
}
//Execute the write command
 void write_ext_eeprom(EEPROM_ADDRESS address, BYTE data) {
     while(!ext_eeprom_ready());
             
             i2c_start();                          //the command is acknowledge
             i2c_write(0xa0);                      //send the control byte last bit is zero so it is a write operation
             i2c_write((BYTE)(address>>8) & 0x7F); //send the Address High Byte
             i2c_write((BYTE)(address) & 0xFF);    //send the Address Low Byte
             i2c_write(data);                      //write the data word to the addressed memory location.
             i2c_stop();                           //send the stop bit
          }
//Execute the read command
BYTE read_ext_eeprom(EEPROM_ADDRESS address) {
    BYTE data;

 while(!ext_eeprom_ready());
        
        i2c_start();                               //the command is acknowledge
        i2c_write(0xa0);                           //send the control byte
        i2c_write((BYTE)(address>>8) & 0x7F);      //send the Address High Byte
        i2c_write((BYTE)(address) & 0xFF);         //send the Address Low Byte
        i2c_start();                               //send start bit
        i2c_write((0xa0)|1);                       //send control byte with last bit being 1 (for read operation)
        data=i2c_read(0);                          //obtain the data from that location, no acknowledge
        i2c_stop();                                //send stop bit
 
 return(data++);                                   //return the data
              }

void main()
{
 
   BYTE value, cmd;                             //value:stores the data cmd: stores the command
   int block_10Data = 0;                        //flag used to idendify the 10 block data read/write
   EEPROM_ADDRESS address;                      //Address:stores the location in memory
   printf("\n\rInit...");                       //display in the GUI
   init_ext_eeprom();                           //Initiate

  while(true){
        do{
           if(kbhit()){
           cmd = getc();                        //get character from keyboard
           cmd = toupper(cmd);                  //convert it uppercase
           putc(cmd);                           //display in the GUI
              if(( cmd!='R') && (cmd!='W'))     //If R nor W entered 
              printf("\n\rRead or Write: ");    //display in the GUI
          }
          // if the cmd is "C" then the 10 data block was clicked
          else if(cmd == 'C'){
            block_10Data = 1;                   //flag should be high
          }
          delay_ms(1);
        }while((cmd!= 'R')&&(cmd!='W'));       //will run until R or W is pressed
        
       printf("\n\rAddress Location: ");       //Display on the GUI
       address = gethex();                     //input the address high byte
       address = (address << 8);               //shift it to the right by one byte 
       address += gethex();                    //input the address low byte
      
      //When R is pressed as a command
      if(cmd=='R'){
         //10 data block flag high
         if(block_10Data== 1){
             printf("\r\n");
            // Display 10 address with their data values 
            for(int i = 0; i <= 9; i++){
               printf("\n\rAddress location: %X",address);
               printf(" -- Data value: %X\r\n",read_ext_eeprom(address));
               address=address+0001;            //Increment the address location by 1
            }
            block_10Data = 0;                   //reset the 10 data block flag
         }
         //10 data block flag low - individual read command
         else
         printf(" -- Data value: %X\r\n",read_ext_eeprom(address));//display the data value at that address
       }
 
        //When W is pressed as a command
        if(cmd=='W'){
            //10 data block flag high
            if(block_10Data == 1){
               // Display 10 address with a new value
               for(int i = 0; i <= 9; i++){
               printf("\r\nAddress location:%X",address);  
               printf(" -- New data value: ");  //Display on GUI
               value = gethex();                //input new value
               write_ext_eeprom(address, value);//write new value to the memory chip
               printf("\r\n");                  //Start from the beginning of the next line
               address = address + 0001;        //Increment the address location by 1.
            }
               block_10Data = 0;                //reset the 10 data block flag
        }
            //10 data block flag low - individual write command
            else{
               printf(" -- New value: ");       //display on GUI
               value = gethex();                //input new value
               write_ext_eeprom(address, value);//write new value to the memory chip
               printf("\r\n");                  //Start from the beginning of the next line
             }
        }
        cmd = 0;                                //reset the command
  }
} 
