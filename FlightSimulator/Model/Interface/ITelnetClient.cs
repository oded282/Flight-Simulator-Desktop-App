using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    interface ITelnetClient
    {
        void connect();
        void write(string command);
        string read(); // blocking call
        void disconnect();
        void start(string command);
    
    }
}
