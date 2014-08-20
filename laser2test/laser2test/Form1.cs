using PositionListener.UDPCommunication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laser2test
{
    public partial class Form1 : Form,IMessageHandler
    {
        public const int COMMPORT = 21500;

        public void displayOutput(String output)
        {
            this.Invoke((MethodInvoker)delegate
            {
                label1.Text = output;
            });
        }

        protected UDPCommManager commManager;
        public Form1()
        {
            InitializeComponent();
            commManager = new UDPCommManager(this, COMMPORT);
        }

        public void onMessageReceived(System.Net.IPAddress sender, byte[] buffer, int length)
        {
            displayOutput(DateTime.Now.ToString() + Encoding.UTF8.GetString(buffer));
            //label1.Text = DateTime.Now.ToString();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            commManager.cleanup();
        }
    }
}
