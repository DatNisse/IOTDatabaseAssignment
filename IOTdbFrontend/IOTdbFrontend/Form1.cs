using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOTdbFrontend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void SendBoxes()
        {
            Program.IOTSendUnit = new IotUnit();
            Program.IOTSendUnit.DeviceID = this.editBoxID.Text;
            Program.IOTSendUnit.IPadress = this.editBoxIP.Text;
            Program.IOTSendUnit.Timestamp = DateTime.Now.Ticks;
            Program.IOTSendUnit.DeviceType = this.editBoxType.Text;
            Program.IOTSendUnit.DeviceCategory = this.editBoxCategory.Text;
            Program.IOTSendUnit.Value = Convert.ToDouble(this.editBoxValue.Text);
            Program.IOTSendUnit.Unit = this.editBoxUnit.Text;
            Program.ConnectBackendPB("GamePC", "W");
            this.editBoxID.Text = "";
            this.editBoxIP.Text = "";
            this.editBoxType.Text = "";
            this.editBoxCategory.Text = "";
            this.editBoxValue.Text = "";
            this.editBoxUnit.Text = "";
        }

        public void UpdateBoxes()
        {
            Program.ConnectBackendPB("GamePC", "R");

            foreach (IotUnit item in Program.IOTunitListPB.List)
            {
                /*
                this.textBoxID.Text = this.textBoxID.Text + "\n" + item.DeviceID;
                this.textBoxIP.Text = this.textBoxIP.Text + "\n" + item.IPadress;
                this.textBoxTime.Text = this.textBoxTime.Text + "\n" + item.Timestamp;
                this.textBoxType.Text = this.textBoxType.Text + "\n" + item.DeviceType;
                this.textBoxCategory.Text = this.textBoxCategory.Text + "\n" + item.DeviceCategory;
                this.textBoxValue.Text = this.textBoxValue.Text + "\n" + item.Value.ToString() + item.Unit;
                */
                this.textBoxID.AppendText(item.DeviceID);
                this.textBoxID.AppendText(Environment.NewLine);
                this.textBoxIP.AppendText(item.IPadress);
                this.textBoxIP.AppendText(Environment.NewLine);
                DateTime tempDate = new DateTime(item.Timestamp);
                this.textBoxTime.AppendText(tempDate.ToString());
                this.textBoxTime.AppendText(Environment.NewLine);
                this.textBoxType.AppendText(item.DeviceType);
                this.textBoxType.AppendText(Environment.NewLine);
                this.textBoxCategory.AppendText(item.DeviceCategory);
                this.textBoxCategory.AppendText(Environment.NewLine);
                this.textBoxValue.AppendText(item.Value.ToString() + item.Unit);
                this.textBoxValue.AppendText(Environment.NewLine);
            }
            /*
            foreach (IOTunit unit in Program.IOTunitList)
            {
                this.textBoxID.Text = this.textBoxID.Text + "\n" + unit.GetDeviceId();                
                this.textBoxIP.Text = this.textBoxIP.Text + "\n" + unit.GetIPAddress().ToString();
                this.textBoxTime.Text = this.textBoxTime.Text + "\n" + unit.GetTimeStamp().ToString();
                this.textBoxType.Text = this.textBoxType.Text + "\n" + unit.GetDeviceType();
                this.textBoxCategory.Text = this.textBoxCategory.Text + "\n" + unit.GetDeviceCatagory();
                this.textBoxValue.Text = this.textBoxValue.Text + "\n" + unit.GetValue().ToString() + unit.GetUnit();                
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateBoxes();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Send_Click(object sender, EventArgs e)
        {
            SendBoxes();
        }
    }
}
