using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulator.ViewModels;

using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace FlightSimulator.Views
{

    public partial class FlightBoard : UserControl
    {
        FlightBoardViewModel vm_flightBoard;
        ObservableDataSource<Point> planeLocations = null;

        public FlightBoard()
        {
            InitializeComponent();
            
        }

        public void setVM(FlightBoardViewModel vm_f)
        {
             vm_flightBoard = vm_f;
             vm_flightBoard.PropertyChanged += Vm_PropertyChanged;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            planeLocations = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);

            plotter.AddLineGraph(planeLocations, 2, "Route");
        }

        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("Lat") || e.PropertyName.Equals("Lon"))
            {
                // set the point by lat and lon. lat is x value and lon is y value.
                Point p1 = new Point(vm_flightBoard.Lat, vm_flightBoard.Lon);           
                Console.Write(p1.ToString());
                
                planeLocations.AppendAsync(Dispatcher, p1);
            }
        }
       
    }

}

