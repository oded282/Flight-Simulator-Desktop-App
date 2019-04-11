using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel
    {

        private string _dataText;

        public AutoPilotViewModel()
        {
            _dataText = "set controls/flight/rudder 1\r\n";
        }

        public string DataText
        {
            get
            {
                System.Console.WriteLine("_dataText get");

                return _dataText;
            }
            set
            {
                System.Console.WriteLine("_dataText set");
                _dataText = value;
            }
        }
       
        #region OkCommand
        private ICommand _okCommand;
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => OkClick()));
            }
        }
        private void OkClick()
        {
            ApllicationClientModel.write(_dataText);

        }
        #endregion

    }

}
