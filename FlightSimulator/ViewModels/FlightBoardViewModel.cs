using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Views;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
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
                return _settingsCommand ?? (_settingsCommand = new CommandHandler(() => _connectCommandClick()));
            }
        }
        private void _connectCommandClick()
        {
            ApllicationClientModel.connect();
        }
        #endregion

    }

}

#endregion