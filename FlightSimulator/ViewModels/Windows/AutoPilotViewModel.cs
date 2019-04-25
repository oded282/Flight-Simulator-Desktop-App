using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{

    class AutoPilotViewModel : BaseNotify
    {

        private string _dataText;

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

            ClearClick();

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

            DataText = "";
        }
        #endregion

    }

}
