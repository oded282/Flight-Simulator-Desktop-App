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
        // elevator of joystic proprty.
        public string VM_Elevator
        {
            get
            {
                return _elevator;
            }
            set
            {
                _elevator = value;
                // send commad to the flight simolator to change the elevator. 
                ApllicationClientModel.write("set /controls/flight/elevator " + value);
            }
        }
        // throttle of joystic proprty.
        public string VM_Throttle
        {
            get
            {

                return _throttle;
            }
            set
            {
                _throttle = value;
                // send commad to the flight simolator to change the throttle.
                ApllicationClientModel.write("set /controls/engines/current-engine/throttle " + value);
            
            }

        }
        // rudder slider proprty.
        public string VM_Rudder
        {
            get
            {
                return _rudder;
            }
            set
            {
                _rudder = value;
                // send commad to the flight simolator to change the rudder.
                ApllicationClientModel.write("set /controls/flight/rudder " + value);

            }
        }

    }
}
