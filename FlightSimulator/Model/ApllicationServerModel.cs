using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.Model
{
    class ApllicationServerModel : IServerModel
    {
        TcpListener listener;




        public void close()
        {
            throw new NotImplementedException();
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

        public string start()
        {
            Console.WriteLine("Listening...");
            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            //---read incoming stream---
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            //---convert the data received into a string---
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received : " + dataReceived);

            //---write back the text to the client---
            Console.WriteLine("Sending back : " + dataReceived);
            nwStream.Write(buffer, 0, bytesRead);
            client.Close();
            listener.Stop();
            Console.ReadLine();

            return " ";
        }
    }
}
