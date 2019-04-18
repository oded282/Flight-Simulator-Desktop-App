using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{

    class ManualViewModel
    {
        private string _aileron;
        private string _elevator;
        private string _throttle;
        private string _rudder;

        public string VM_Aileron
        {
            get
            {

                return _aileron;
            }
            set
            {

                _aileron = value;
                ApllicationClientModel.write("set /controls/flight/aileron " + value);


            }

        }
        public string VM_Elevator
        {
            get
            {
                System.Console.WriteLine("_dataText get");

                return _elevator;
            }
            set
            {

                _elevator = value;
                ApllicationClientModel.write("set /controls/flight/elevator " + value);

            }


        }
        public string VM_Throttle
        {
            get
            {

                return _throttle;
            }
            set
            {

                _throttle = value;
                ApllicationClientModel.write("set /controls/engines/current-engine/throttle " + value);


            }

        }

        public string VM_Rudder
        {
            get
            {
                System.Console.WriteLine("_dataText get");

                return _rudder;
            }
            set
            {

                _rudder = value;
                ApllicationClientModel.write("set /controls/flight/rudder " + value);

            }
        }

    }
}
