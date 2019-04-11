using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    interface IServerModel
    {
        void open();
        string read(); // blocking call
        void close();

    }
}
