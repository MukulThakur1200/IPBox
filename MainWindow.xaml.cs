using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Net;
using System.Windows.Shapes;


namespace WpfApp2
{  

    public partial class MainWindow : Window
    {
        Program p1;
        string sendingmessage;
        public MainWindow()
        {
            InitializeComponent();

            p1 = new Program();
            p1.listening();
            this.DataContext = p1;
            ip1.Hide_LocalHost_btn();
            ip1.fill("192.168.2.37");
        }
        private void eventchecker(object sender, KeyEventArgs e)
       {
            if (e.Key == Key.Enter)
            {
                Sendmessage(this, new RoutedEventArgs());
                sendmessageinput.Text = "";
            }
        }
        private void Sendmessage(object sender, RoutedEventArgs e)
        {

            sendingmessage = sendmessageinput.Text;
            p1.send(sendingmessage);
            sendmessageinput.Text = "";
        }

        public void stop(object sender, RoutedEventArgs e)
        {
            string remoteip = ip1.Value();
            string port = ip2.Value();
            p1.stop();
        }

        public void Connect(object sender, RoutedEventArgs e)
        {
            string remoteip = ip1.Value();
            string port = ip2.Value();
            p1.connect(remoteip, port);
        }
    }
}
