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
        double EPSILON = 0.002;



       
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
              
            Console.WriteLine("Listening...");
            listener.Start();

                //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client accepted");

            Thread t = new Thread(delegate ()
              {

            //---get the incoming data through a network stream---
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[512];

                Thread.Sleep(10000);
                Console.WriteLine("New Thread");
                while (isConnected)
                {
                    int index = 0;
                    string str = "";
                    //---read incoming stream---
                    int bytesRead = nwStream.Read(buffer, 0, 512);

                    //---convert the data received into a string---
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    string[] dataBlock = Regex.Split(dataReceived, "\n");
                    

                    while (index < dataBlock.Length)
                    {
                        string[] allCommands = Regex.Split(dataBlock[index], ",");

                        allCommands = allCommands.Where(val => val != "").ToArray();


                    // the remainder from the previous block data.
                    if ((allCommands.Length < 24 && index == 0) || allCommands.Length == 0 || allCommands[0] == "-")
                    {
                        index++;
                        continue;
                    }
                    // the first commands in block when lon is already sampled.
                    else if (allCommands.Length == 24 && index == 0)
                    {
                        M_lat = allCommands[0];
                    }
                    // the last block whit len of 1.
                    else if (allCommands.Length == 1)
                    {
                        M_lon = allCommands[0];
                    }
                    else
                    {
                        if ((Convert.ToDouble(allCommands[0]) < Convert.ToDouble(m_lon) - EPSILON || Convert.ToDouble(allCommands[0]) > Convert.ToDouble(m_lon) + EPSILON) &&
                            (Convert.ToDouble(allCommands[1]) < Convert.ToDouble(m_lat) - EPSILON || Convert.ToDouble(allCommands[1]) > Convert.ToDouble(m_lat) + EPSILON))
                        {
                           
                            M_lon = allCommands[0];
                            M_lat = allCommands[1];
                        }
                    }
                        index++;
                    }

                    Thread.Sleep(100);
                }
            });
            t.Start();
            
            
        }

    }
}
