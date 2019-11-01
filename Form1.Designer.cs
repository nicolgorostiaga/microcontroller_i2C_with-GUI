namespace Anokhin_Nicol_Lab7_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Send = new System.Windows.Forms.Button();
            this.write_radioButton = new System.Windows.Forms.RadioButton();
            this.read_radioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.data_box = new System.Windows.Forms.TextBox();
            this.address_box = new System.Windows.Forms.TextBox();
            this.Clear_button = new System.Windows.Forms.Button();
            this.display = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.block_10Data = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(440, 206);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 58);
            this.Send.TabIndex = 20;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // write_radioButton
            // 
            this.write_radioButton.AutoSize = true;
            this.write_radioButton.Location = new System.Drawing.Point(16, 247);
            this.write_radioButton.Name = "write_radioButton";
            this.write_radioButton.Size = new System.Drawing.Size(79, 17);
            this.write_radioButton.TabIndex = 18;
            this.write_radioButton.Text = "Write_Data";
            this.write_radioButton.UseVisualStyleBackColor = true;
            this.write_radioButton.CheckedChanged += new System.EventHandler(this.write_CheckedChanged);
            this.write_radioButton.Click += new System.EventHandler(this.write_Click);
            // 
            // read_radioButton
            // 
            this.read_radioButton.AutoSize = true;
            this.read_radioButton.Location = new System.Drawing.Point(16, 221);
            this.read_radioButton.Name = "read_radioButton";
            this.read_radioButton.Size = new System.Drawing.Size(80, 17);
            this.read_radioButton.TabIndex = 17;
            this.read_radioButton.Text = "Read_Data";
            this.read_radioButton.UseVisualStyleBackColor = true;
            this.read_radioButton.CheckedChanged += new System.EventHandler(this.read_CheckedChanged);
            this.read_radioButton.Click += new System.EventHandler(this.read_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Address";
            // 
            // data_box
            // 
            this.data_box.Location = new System.Drawing.Point(203, 270);
            this.data_box.Name = "data_box";
            this.data_box.Size = new System.Drawing.Size(189, 20);
            this.data_box.TabIndex = 14;
            // 
            // address_box
            // 
            this.address_box.Location = new System.Drawing.Point(203, 221);
            this.address_box.Name = "address_box";
            this.address_box.Size = new System.Drawing.Size(189, 20);
            this.address_box.TabIndex = 13;
            // 
            // Clear_button
            // 
            this.Clear_button.Location = new System.Drawing.Point(440, 276);
            this.Clear_button.Name = "Clear_button";
            this.Clear_button.Size = new System.Drawing.Size(75, 41);
            this.Clear_button.TabIndex = 12;
            this.Clear_button.Text = "Clear";
            this.Clear_button.UseVisualStyleBackColor = true;
            this.Clear_button.Click += new System.EventHandler(this.Clear_button_Click);
            // 
            // display
            // 
            this.display.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.display.AllowDrop = true;
            this.display.Location = new System.Drawing.Point(12, 12);
            this.display.Multiline = true;
            this.display.Name = "display";
            this.display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.display.Size = new System.Drawing.Size(499, 184);
            this.display.TabIndex = 11;
            this.display.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM4";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // block_10Data
            // 
            this.block_10Data.AutoSize = true;
            this.block_10Data.Location = new System.Drawing.Point(16, 276);
            this.block_10Data.Name = "block_10Data";
            this.block_10Data.Size = new System.Drawing.Size(67, 17);
            this.block_10Data.TabIndex = 21;
            this.block_10Data.Text = "10_Data";
            this.block_10Data.UseVisualStyleBackColor = true;
            this.block_10Data.Click += new System.EventHandler(this.block_10Data_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(532, 331);
            this.Controls.Add(this.block_10Data);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.write_radioButton);
            this.Controls.Add(this.read_radioButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.data_box);
            this.Controls.Add(this.address_box);
            this.Controls.Add(this.Clear_button);
            this.Controls.Add(this.display);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.RadioButton write_radioButton;
        private System.Windows.Forms.RadioButton read_radioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox data_box;
        private System.Windows.Forms.TextBox address_box;
        private System.Windows.Forms.Button Clear_button;
        private System.Windows.Forms.TextBox display;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.CheckBox block_10Data;
    }
}

