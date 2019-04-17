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
        private string _background;

        public AutoPilotViewModel()
        {
            _dataText = "set controls/flight/rudder 1\r\n";
        }

        public string Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
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
                if (value != "")
                {
                    Background = "Pink";
                }

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

        #region clearCommand
        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => ClearClick()));
            }
        }
        private void ClearClick()
        {
            
            _dataText = "";
        }
        #endregion



    }

}
