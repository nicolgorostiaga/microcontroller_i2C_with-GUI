using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anokhin_Nicol_Lab7_1
{
    public partial class Form1 : Form
    {
        //*****************Initialize the form******************************************//
        public Form1()
        {
            InitializeComponent();          //Initiate the form
        }
        //************************Load the form****************************************//
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();                         //open the serial port
            }
            catch (UnauthorizedAccessException)             //Not connected to port
            {
                MessageBox.Show("Cannot open COM4 port ! \nPlease select another port");
            }
            catch
            {
                MessageBox.Show("Configure the port.");     //Not connected to port
            }
        }
        //******************Data will transfer through serial***************************//
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            AddTextToLabel(serialPort1.ReadExisting());     //send data
        }
        //************* Invoke if data is being sent serially **********************//
        public delegate void AddnewText(string str);
        public void AddTextToLabel(string str)
        {
            if (this.display.InvokeRequired)
            {
                //str variable will hold the value entered
                this.Invoke(new AddnewText(AddTextToLabel), str);
            }
            else
            {
                //will accumulate the values entered and display on GUI
                this.display.Text += str;
            }
        }
        //****************Clear the GUI screen**********************************//
        private void Clear_button_Click(object sender, EventArgs e)
        {
            display.Clear();                // Will clear the screen of the GUI
        }

        //***************Close serial Port connection**************************//
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();            //close
        }
        //***************When send button is clicked**************************//
        private void Send_Click(object sender, EventArgs e)
        {
            // if the read radio button is clicked
            if (read_radioButton.Checked == true)
            {
                serialPort1.Write(address_box.Text);//send the address to the pic code
                address_box.Text = "";              //clear the address box
            }
            // if the write radio button is clicked
            else if (write_radioButton.Checked == true)
            {
                serialPort1.Write(address_box.Text);//send the address to the pic code
                address_box.Text = "";              //clear the address box
                serialPort1.Write(data_box.Text);   //send the data entered
                data_box.Text = "";                 //clear the data box
            }
        }
        //**************When the read radio button is clicked***********************//
        private void read_Click(object sender, EventArgs e)
        {
            //if the read radio button is clicked
            if (read_radioButton.Checked == true)
            {
                serialPort1.Write("R");             //send R to pic code
            }
        }
        //************* When the write radio button is clicked***********************//
        private void write_Click(object sender, EventArgs e)
        {
            //If the write radio button is clicked
            if (write_radioButton.Checked == true)
            {
                serialPort1.Write("W");           //send W to pic code
            }
        }
        //********** 10 BLOCK OF DATA*************************************************//
        private void block_10Data_Click(object sender, EventArgs e)
        {
            //If the 10 data block is clicked
            if (block_10Data.Checked == true)
            {
                serialPort1.Write("C");         //send C to pic code
            }
        }
        //***********User can't enter any data**************************************//
        private void read_CheckedChanged(object sender, EventArgs e)
        {
            //If the read radio button is clicked
            if (read_radioButton.Checked == true)
                data_box.Enabled = false;       //can't enter values in the data box
        }
        //**********User can enter data
        private void write_CheckedChanged(object sender, EventArgs e)
        {
            //If the write radio button is clicked
            if (write_radioButton.Checked == true)
                data_box.Enabled = true;        //can enter values in the data box
        }
    }
}
