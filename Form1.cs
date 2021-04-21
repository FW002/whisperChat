using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace whisperChat
{
    public delegate void FuncType(string aStatus);
    public delegate void MessageType(string aMessage, int count);

   

    public partial class Form1 : Form
    {
        public static Form1 frm;
        public FuncType statusPtr;
        public int userCount = 0;
        Thread serTHR;
        public Form1()
        {
            InitializeComponent();
            frm = this;
            statusPtr = this.displayServerStatus;
            MainLoop();
        }

        private void OnNewUserClick(object sender, EventArgs e)
        {
            userCount++;
            clientForm newF = new clientForm();
            newF.Show();
        }

        void displayServerStatus(string msg)
        {
            chatOutPutServer.Items.Add(msg);
        }

        private void MainLoop()
        {
            serTHR = new Thread(startServer);
            serTHR.Start();
        }

        void startServer()
        {
            MessageProcessing newServer = new MessageProcessing();
            
            newServer.Server();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            serTHR.Abort();
            base.OnFormClosing(e);
        }
    }
}
