using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace whisperChat
{
    class MessageProcessing 
    {

        public List<string> userlist = new List<string>(new string[] { });

        static IPAddress GetIPAddress()
        {
            IPAddress ipAdr = Dns.Resolve("localhost").AddressList[0];
            // IPAddress ipAdr = Dns.Resolve("device").AddressList[0];
            // return Dns.Resolve("192.168.83.1").AddressList[0];
            // return Dns.GetHostEntry("192.168.83.1").AddressList[0];
            return ipAdr;
        }

        public void Server()
        {
            TcpListener server;
            Socket socke;
            IPAddress ipAdr = GetIPAddress();
            int clientCount = 0;
            try
            {
                server = new TcpListener(ipAdr, 5000);
                server.Start();
                Console.WriteLine("Server {0} gestartet", server.LocalEndpoint);

                string serverStarted = "Server started: " + server.LocalEndpoint.ToString();
                Form1.frm.BeginInvoke(Form1.frm.statusPtr, serverStarted); // send server status to form

                while (true)
                {
                    socke = server.AcceptSocket(); // Aufruf blockiert!!
                                                   // ein Client hat eine Verbindung zu uns aufgebaut
                                                   // socke repräsentiert diese Verbindung
                                                   // ein neuer Thread wird gestartet welcher nun die Kommunikation mit diesem Client abwickelt
                    clientCount++;
                    new ConnTalk(socke, clientCount);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e);
                Form1.frm.BeginInvoke(Form1.frm.statusPtr, e);
            }
        }

        static void PrintConnectionInfo(Socket aSock)
        {
            Console.WriteLine("Anfrage von {0}", aSock.RemoteEndPoint);
        }

        public void Client()
        {
            const string serverName = "localhost";
            UserQueue userq = new UserQueue();
        
            // const string serverName = "192.168.83.1";
            try
            {
                TcpClient client = new TcpClient(serverName, 5000);
                NetworkStream strm = client.GetStream();
                Socket sc = client.Client;
                StreamReader strmRd = new StreamReader(strm);
                StreamWriter strmWr = new StreamWriter(strm);
                string txt, txt2;

                txt = "empty";
                Console.WriteLine("Connected to {0}", sc.RemoteEndPoint);

                userlist.Add(sc.RemoteEndPoint.ToString()); // save remote endpoint of every connected user

                while (true)
                {
                    txt = strmRd.ReadLine();
                    //foreach(string c in userlist)
                    //{
                     clientForm.clientfrm.BeginInvoke(clientForm.clientfrm.TraceFuncPtr, txt);
                    //}
                    
                }

                // Client samt NetworkStream schließen
                // sc.Shutdown(SocketShutdown.Both); sc.Close();

                client.Close(); strmRd.Close(); strmWr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Form1.frm.BeginInvoke(Form1.frm.statusPtr, e);
            }
        }

    }

    public class MessageQueue
    {
        public Queue<string> _msg = new Queue<string>();

        public void addMsg(string msg)
        {
            lock (this)
            {
                _msg.Enqueue(msg);
                Console.WriteLine("{0}",msg);
                Monitor.Pulse(this);
            }
        }

        public string distributeMsg()
        {
            lock (this)
            {
                if(_msg.Count == 0)
                {
                    Monitor.Wait(this);
                }
                return _msg.Dequeue();
            }
        }
    }

    public class UserQueue
    {
        public Queue<string> _user = new Queue<string>();


        public void addUser(Socket aUser, int userCount)
        {
            lock (this)
            {
                string user = "User " + userCount.ToString();

                _user.Enqueue(user);
                Console.WriteLine(user);
                Monitor.Pulse(this);
            }
        }

        public string deleteUser()
        {
            lock (this)
            {
                if (_user.Count == 0)
                {
                    Monitor.Wait(this);
                }

                return _user.Dequeue();
            }
        }

        //public string printUser(int id)
        //{
        //    string uId = id.ToString();
        //    string wrt = 
        //    return wrt;
        //}
    }


    class ConnTalk : MessageProcessing
    {
       
        Thread m_Thr;
        Socket m_Sc;
        int userID;
        UserQueue q = new UserQueue();

        public ConnTalk(Socket aSc, int aCount)
        {
            m_Sc = aSc;
            m_Thr = new Thread(this.TalkWithClient);
            userID = aCount;
            m_Thr.Start();

            //getMsgFromClient = this.processMsg;

            q.addUser(aSc, aCount);
        }


        void TalkWithClient()
        {
            NetworkStream strm = new NetworkStream(m_Sc);
            StreamReader strmRd = new StreamReader(strm);
            StreamWriter strmWr = new StreamWriter(strm);

            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();

            string txt = null;

            string endConn = "User Disconnected: ";
            string user = q.deleteUser();

            //userlist.Add(user);

            string clientStatus = "Client connected: " + user;
            Form1.frm.BeginInvoke(Form1.frm.statusPtr, clientStatus); // send client status to form

            Console.WriteLine("Talking with {0}", user);
      
            try
            {
               
                while (true)
                {
                    
                   //txt = clientForm.clientfrm.themsg;
                   // Console.WriteLine(msq._msg.Count);
                    
                    lock (this)
                    {
                        txt = clientForm.clientfrm.queue.distributeMsg();
                        Monitor.Pulse(this);
                    }


                    if (txt == null)
                    {
                        txt = "Message corrupted or empty";
                    }else if(txt == "!quit")
                    {
                       // strmWr.Write(endConn);
                        //clientStatus = "User disconnected " + user.ToString();
                        //Form1.frm.BeginInvoke(Form1.frm.statusPtr, clientStatus);
                        break;
                    }
                    //clientForm.clientfrm.sendSignal(1);

                    Console.WriteLine("{0}: {1}", user, txt);



                    //txt += " CALLBACK \r\n";
                    txt += "ECHO\r\n";

                    strmWr.Write(txt); //Talk back to client
                    strmWr.Flush();
                    
                    
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Communication");
            }

            Console.WriteLine("{0} Disconnected", user);
            endConn = endConn += m_Sc.RemoteEndPoint.ToString();
            strmWr.Write(endConn);
            strmWr.Flush();
            // m_Sc.Shutdown(SocketShutdown.Both); 
            m_Sc.Close(); strm.Close(); strmRd.Close(); strmWr.Close();
            return;
        }
    }

}
