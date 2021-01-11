using System;
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
            //Collects data for transfer
            Program.IOTSendUnit = new IotUnit();
            Program.IOTSendUnit.DeviceID = this.editBoxID.Text;
            Program.IOTSendUnit.IPadress = this.editBoxIP.Text;
            Program.IOTSendUnit.Timestamp = DateTime.Now.Ticks;
            Program.IOTSendUnit.DeviceType = this.editBoxType.Text;
            Program.IOTSendUnit.DeviceCategory = this.editBoxCategory.Text;
            Program.IOTSendUnit.Value = Convert.ToDouble(this.editBoxValue.Text);
            Program.IOTSendUnit.Unit = this.editBoxUnit.Text;
            Program.ConnectBackend("GamePC", "W");

            //Resets textboxes
            this.editBoxID.Text = "";
            this.editBoxIP.Text = "";
            this.editBoxType.Text = "";
            this.editBoxCategory.Text = "";
            this.editBoxValue.Text = "";
            this.editBoxUnit.Text = "";
        }

        public void UpdateBoxes()
        {
            Program.ConnectBackend("GamePC", "R");

            //Populates textfields
            foreach (IotUnit item in Program.IOTunitListPB.List)
            {
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
