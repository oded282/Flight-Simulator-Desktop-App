using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.Model
{
    class ApllicationServerModel : ModelNotify, IServerModel
    {
        TcpListener listener;
        TcpClient client;
        bool isConnected = true;
        string m_lon = "0";
        string m_lat = "0";


        public string M_lon
        {
            get {
                return m_lon;
            }
            set {
                m_lon = value;
                NotifyPropertyChanged("lon");
            }
        }

        public string M_lat
        {
            get
            {
                return m_lat;
            }
            set
            {
                m_lat = value;
                NotifyPropertyChanged("lat");
            }
        }



        public void close()
        {
            if (client == null) {
                Console.WriteLine("Server not connected - can't disconnect");
                return;
            }
            client.Close();
            listener.Stop();
            isConnected = false;
        }

        public void open()
        {
            ISettingsModel settings = ApplicationSettingsModel.Instance;

            IPAddress localAdd = IPAddress.Parse(settings.FlightServerIP);
            listener = new TcpListener(localAdd, settings.FlightInfoPort);

            
        }

        public string read()
        {
            throw new NotImplementedException();
        }

        public void start()
        {
            //new Thread(delegate ()
            //{
                Console.WriteLine("Listening...");
                listener.Start();

                //---incoming client connected---
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client accepted");

                //---get the incoming data through a network stream---
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

           
                Console.WriteLine("New Thread");
                while (isConnected)
                {
                    string str = "";
                    //---read incoming stream---
                    int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                    //---convert the data received into a string---
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    string[] allCommands = Regex.Split(dataReceived, ",");
                    m_lon = allCommands[0];
                    m_lat = allCommands[1];
                    
                    Console.WriteLine("Received : " + dataReceived);
                }
            //}).Start();
        }

    }
}
