using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Views;
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

        ApllicationServerModel serverModel;

        public FlightBoardViewModel() {
            serverModel = new ApllicationServerModel();
            serverModel.PropertyChanged += m_PropertyChanged;
        }
        public double Lon
        {
           
            get {
                NotifyPropertyChanged("lon");
                return Convert.ToDouble(serverModel.M_lon); }
            
        }

        public double Lat
        {
            get {
                NotifyPropertyChanged("lat");
                return Convert.ToDouble(serverModel.M_lat); }
        }


        private void m_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.Equals("lat"))
            {
                NotifyPropertyChanged("lat");
            }
            else {
                NotifyPropertyChanged("lon");
            }
        }


        #region Commands
        #region ClickCommand
        private ICommand _settingsCommand;

        public ICommand SettingsCommand
        {
            get
            {
                return _settingsCommand ?? (_settingsCommand = new CommandHandler(() => settingsClick()));
            }
        }
        private void settingsClick()
        {
            var SettingsWin = new SettingWindow();
            SettingsWin.Show();
        }
        #endregion

        
        #region ClickCommand
        private ICommand _connectCommand;
        
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => _connectCommandClick()));
            }
        }
        private void _connectCommandClick()
        {
            ApllicationClientModel.connect();
            //serverModel.open();
            //serverModel.start();
        }
        #endregion

        #region ClickCommand
        private ICommand _disconnectCommand;

        public ICommand DisconnectCommand
        {
            get
            {
                return _disconnectCommand ?? (_disconnectCommand = new CommandHandler(() => _disconnectCommandClick()));
            }
        }
        private void _disconnectCommandClick()
        {
            ApllicationClientModel.disconnect();
            serverModel.close();
        }
        #endregion

    }

}

#endregion