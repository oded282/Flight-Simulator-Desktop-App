using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlightSimulator.ViewModels.Windows
{
    /*
     * This vm  in charge of the the settings window in the mvvm architecture.
     */ 
    public class SettingsWindowViewModel : BaseNotify
    {
        private ISettingsModel model;
        string serverIp = "127.0.0.1";
        int serverPort = 5402;
        int infoPort = 5400;


        public SettingsWindowViewModel(ISettingsModel model)
        {
            this.model = model;
        }

        public string FlightServerIP
        {
            get { return model.FlightServerIP; }
            set
            {
                model.FlightServerIP = value;
                NotifyPropertyChanged("FlightServerIP");
            }
        }

        public int FlightCommandPort
        {
            get { return model.FlightCommandPort; }
            set
            {
                model.FlightCommandPort = value;
                NotifyPropertyChanged("FlightCommandPort");
            }
        }

        public int FlightInfoPort
        {
            get { return model.FlightInfoPort; }
            set
            {
                model.FlightInfoPort = value;
                NotifyPropertyChanged("FlightInfoPort");
            }
        }

        // This property saves the ip,port settings.
        public void SaveSettings()
        {
            model.SaveSettings();
        }

        //This command reload the default settings.
        public void ReloadSettings()
        {
            model.ReloadSettings();
        }

        // This command activated when ok button clicked.
        #region Commands
        #region ClickCommand
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {         
            model.SaveSettings();          
        }
        #endregion

        // This command activated when cancel button clicked.
        #region CancelCommand
        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => OnCancel()));
            } 
        }
        private void OnCancel()
        {
            model.ReloadSettings();
        }
        #endregion
        #endregion
    }
}