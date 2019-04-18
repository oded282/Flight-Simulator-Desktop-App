﻿using System;
using System.Collections.Generic;
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

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for GridView.xaml
    /// </summary>
    public partial class FlightBoardView : UserControl
    {

        FlightBoardViewModel vm;
        public FlightBoardView()
        {
            InitializeComponent();
            //FlightBoard f = new FlightBoard();
            FlightBoardViewModel vm = new FlightBoardViewModel();
            DataContext = vm;
            FlightBoard.setVM(vm);

        }
    }
}
