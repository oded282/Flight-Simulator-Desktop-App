using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class MyTelnetClient : ITelnetClient
    {
        TcpClient client;

        public void connect()
        {
            try
            {
                string ip = Properties.Settings.Default.FlightServerIP;
                int port = Properties.Settings.Default.FlightCommandPort;
                client = new TcpClient();
                client.Connect(ip, port);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void disconnect()
        {
            if (client == null) {
                Console.WriteLine("Client not connected- can't disconnect");
            }
            client.Close();
            client = null;
        }

        public string read()
        {
            throw new NotImplementedException();
        }

        public void write(string command)
        {
            if (client  == null) {
                Console.WriteLine("Client not connected - can't write");
                return;
            }
            NetworkStream nwStream = client.GetStream();
            byte[] byteToSend = ASCIIEncoding.ASCII.GetBytes(command);
            Console.WriteLine(" " + command);
            nwStream.Write(byteToSend, 0, byteToSend.Length);
        }

        public void start(string command)
        {

            //Thread t = (Thread)new Thread(delegate ()
            //{
                write(command);
            //});
            //t.Start();
            //t.Join();
        }
    }
}