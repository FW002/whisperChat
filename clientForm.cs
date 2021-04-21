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
    //public delegate void signalPtr(int sig);
    public partial class clientForm : Form
    {
        public static clientForm clientfrm;

        public FuncType Result2FuncPtr, TraceFuncPtr;
        public MessageType ReceiveMessages;

        //public signalPtr sigp;  //receive signal to let form know, that data is needed

        public int currentUserID = Form1.frm.userCount;

        public MessageQueue queue = new MessageQueue();
        Thread newClient;

    

        public delegate void FuncType1(string aData);

        public clientForm()
        {
            clientfrm = this;
            Console.WriteLine(currentUserID);

            InitializeComponent();

            userLabel.Text = "User: " + currentUserID.ToString();
            ReceiveMessages = this.displayMessages;
            TraceFuncPtr = this.display;
    

            startClientThread();
            //Result2FuncPtr = this.Result2CB;
            //TraceFuncPtr = this.TRaceCB;
        }

        void OnMessageSendClick(object sender, EventArgs e)
        {           
            outPutBoxClient.Items.Add("User " + currentUserID.ToString() + ": " + messageBox.Text.ToString());    
            queue.addMsg(messageBox.Text.ToString());
            messageBox.Clear();
        }


        void displayMessages(string message, int userID)
        {
            outPutBoxClient.Items.Add("User " + userID.ToString() + message);
        }

        void display(string message)
        {          
            outPutBoxClient.Items.Add("User: " + currentUserID.ToString() + " " + message);
        }


        void startClientThread()
        {
            newClient = new Thread(generateNewClient);
            newClient.Start();
           // newClient.Abort();
        }

        void generateNewClient()
        {
            MessageProcessing newClient = new MessageProcessing();
            newClient.Client();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            currentUserID = 0;
            newClient.Abort();
        }


    }
}
