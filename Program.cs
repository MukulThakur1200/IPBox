using System;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using System.Net;
using System.ComponentModel;
using System.Collections;

namespace WpfApp2
{
    public class Program : INotifyPropertyChanged
    {
        private static bool isClientActive = true;
        private string _message;
        TcpClient client = null;
        TcpListener listener = null;
        NetworkStream stream = null;

        public void listening()
        {

            listener = new TcpListener(IPAddress.Parse("192.168.1.47"), 8888);
            listener.Start();

            listener.BeginAcceptTcpClient(DoAcceptTcpClientCallback, null);
        }
        public string message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("message");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void connect(string remoteip, string port)
        {
            client = new TcpClient(remoteip, Convert.ToInt32(port));
            stream = client.GetStream();
            Thread t1 = new Thread(recieve);
            t1.Start();
            if (client != null)
            {
                byte[] sendData = Encoding.ASCII.GetBytes("connected");
                stream.Write(sendData, 0, sendData.Length);

                message += "connected";
            }
        }
        public void stop()
        {
            byte[] sendData = Encoding.ASCII.GetBytes("User Disconnected.......");
            stream.Write(sendData, 0, sendData.Length);

            client.GetStream().Close();
            client.Close();

            client = null;
            stream = null;
        }
        //public void starting(string remoteip, string port)
        //{

        //    try
        //    {               
        //        if (client == null)
        //        {
        //            client = new TcpClient(remoteip, Convert.ToInt32(port));
        //            stream = client.GetStream();
        //            Thread t1 = new Thread(recieve);
        //            t1.Start();
        //        }

        //        if (client != null)
        //        {
        //            message = "Connected";   
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        message = Convert.ToString(e)+ "unable to connect";
        //    }
        //}

        public void send(string send_message)
        {
            try
            {
                string messageToSend = send_message;
                int byteCount = Encoding.ASCII.GetByteCount(messageToSend + 1);
                byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);


                stream.Write(sendData, 0, sendData.Length);

                message = message + "You>> " + send_message + "\n";
                if (messageToSend == "exit")
                {
                    isClientActive = false;
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    if (client != null)
                    {
                        client.Close();
                    }
                }

            }
            catch (Exception e)
            {
                message = "failed to connect...\n";

            }
        }

        public void DoAcceptTcpClientCallback(IAsyncResult asyncResult)
        {

            if (client == null)
            {
                client = listener.EndAcceptTcpClient(asyncResult);
                stream = client.GetStream();
                Thread t1 = new Thread(recieve);
                t1.Start();
            }
            listener.BeginAcceptTcpClient(DoAcceptTcpClientCallback, null);
        }


        public void recieve()
        {
            try
            {
                while (isClientActive)
                {
                    byte[] buffer = new byte[1024];
                    int recv = stream.Read(buffer, 0, buffer.Length);
                    if (recv > 0)
                    {
                        string request = Encoding.UTF8.GetString(buffer, 0, recv);
                        if (request == "exit")
                        {
                            isClientActive = false;
                            message = "User2 has left the chat.....";
                        }
                        else
                        {
                            message = message + "User2 >> " + request + "\n";
                            if (request == "User Disconnected.......")
                            {
                                client.GetStream().Close();
                                client.Close();

                                client = null;
                                stream = null;
                                break;
                            }
                        }
                    }
                    Thread.Sleep(50);
                }

                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                message = "Disconnected";

            }

        }
    }
}









//using System;
//using System.Net.Sockets;
//using System.Text;
//using System.IO;
//using System.Threading;
//using System.Net;
//using System.ComponentModel;
//using System.Collections;

//namespace WpfApp2
//{
//    public class Program : INotifyPropertyChanged
//    {
//        private static bool isClientActive = true;
//        private string _message;
//        TcpClient client = null;
//        TcpListener listener = new TcpListener(IPAddress.Parse("192.168.2.37"), 8888);
//        NetworkStream stream = null;

//        public void listening()
//        {

//           listener.Start();

//            listener.BeginAcceptTcpClient(DoAcceptTcpClientCallback, null);
//        }
//        public string message
//        {
//            get { return _message; }
//            set
//            {
//                _message = value;
//                OnPropertyChanged("message");
//            }
//        }

//        public event PropertyChangedEventHandler PropertyChanged;
//        public void OnPropertyChanged(string property)
//        {
//            if (PropertyChanged != null)
//            {
//                PropertyChanged(this, new PropertyChangedEventArgs(property));
//            }
//        }

//        public void connect(string remoteip , string port)
//        {
//            client = new TcpClient(remoteip, Convert.ToInt32(port));
//            stream = client.GetStream();
//            Thread t1 = new Thread(recieve);
//            t1.Start();
//            if (client != null)
//            {
//                byte[] sendData = Encoding.ASCII.GetBytes("connected");
//                stream.Write(sendData, 0, sendData.Length);

//                message += "connected";
//            }
//        }
//        public void stop()
//        {
//            byte[] sendData = Encoding.ASCII.GetBytes("User Disconnected.......");
//            stream.Write(sendData, 0, sendData.Length);

//            client.GetStream().Close();
//            client.Close();

//            client = null;
//            stream = null;
//        }
//        //public void starting(string remoteip, string port)
//        //{

//        //    try
//        //    {               
//        //        if (client == null)
//        //        {
//        //            client = new TcpClient(remoteip, Convert.ToInt32(port));
//        //            stream = client.GetStream();
//        //            Thread t1 = new Thread(recieve);
//        //            t1.Start();
//        //        }

//        //        if (client != null)
//        //        {
//        //            message = "Connected";   
//        //        }
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        message = Convert.ToString(e)+ "unable to connect";
//        //    }
//        //}

//        public void send(string send_message)
//        {
//            try
//            {
//                string messageToSend = send_message;
//                int byteCount = Encoding.ASCII.GetByteCount(messageToSend + 1);
//                byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);


//                stream.Write(sendData, 0, sendData.Length);

//                message = message + "You>> " + send_message + "\n";
//                if (messageToSend == "exit")
//                {
//                    isClientActive = false;
//                    if (stream != null)
//                    {
//                        stream.Close();
//                    }
//                    if (client != null)
//                    {
//                        client.Close();
//                    }
//                }

//            }
//            catch (Exception e)
//            {
//                message = "failed to connect...\n";
//                stream.Close();
//                client.Close();

//                client = null;
//                stream = null;
//                listening();
//            }
//        }

//        public void DoAcceptTcpClientCallback(IAsyncResult asyncResult)
//        {

//            if (client == null)
//            {
//               client =  listener.EndAcceptTcpClient(asyncResult);
//                stream = client.GetStream();
//                Thread t1 = new Thread(recieve);
//                t1.Start();
//                listener.Stop();
//            }
//            //listener.BeginAcceptTcpClient(DoAcceptTcpClientCallback, null);
//        }


//        public void recieve()
//        {
//            try
//            {
//                while (isClientActive)
//                {
//                    byte[] buffer = new byte[1024];
//                    int recv = stream.Read(buffer, 0, buffer.Length);
//                    if (recv > 0)
//                    {
//                        string request = Encoding.UTF8.GetString(buffer, 0, recv);
//                        if (request == "exit")
//                        {
//                            isClientActive = false;
//                            message = "User2 has left the chat.....";
//                        }
//                        else
//                        {
//                            message = message + "User2 >> " + request + "\n";
//                            if (request == "User Disconnected.......")
//                            {
//                                stream.Close();
//                                client.Close();

//                                client = null;
//                                stream = null;
//                                break;
//                            }
//                        }
//                    }
//                    Thread.Sleep(50);
//                }

//                Thread.Sleep(1000);
//            }
//            catch (Exception e)
//            {
//                message = "Disconnected";
//                if (client == null)
//                {
//                    stream.Close();
//                    client.Close();

//                    client = null;
//                    stream = null;
//                }
//                listening();
//            }

//        }
//    }
//}
