using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    /*
     * This vm is in charge of the auto pilot in the mvvm architecure.
     */
    class AutoPilotViewModel : BaseNotify
    {

        private string _dataText;

        // This property contains the command written in the auto pilot text box.
        public string DataText
        {
            get
            {             
                return _dataText;
            }
            set
            {
                _dataText = value;
                NotifyPropertyChanged(value);
            }
        }

        // This command activated when ok button clicked and send to the simulator command.
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
            ApllicationClientModel.write(_dataText); // write to the simulator.

            ClearClick();

        }
        #endregion
         
        // This property activated when clear button clicked and erase the content from the text box.
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

            DataText = "";
        }
        #endregion

    }

}
