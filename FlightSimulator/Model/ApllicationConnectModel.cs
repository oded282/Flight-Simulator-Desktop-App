using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.Model
{
    /*
     * This class responsible of communication with the server, by injecting the prefferd telnet client.
     */
    public static class ApllicationClientModel
    {
         private static ITelnetClient telnetClient = new MyTelnetClient();

        public static void connect()
        {
            telnetClient.connect();
        }

        public static void disconnect()
        {
            telnetClient.disconnect();
        }

        public static void write(string command)
        {
            telnetClient.start(command);
        }

    }
}
