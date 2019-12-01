﻿using Auction_House_WPF.ViewModels;
using System;
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
using System.Windows.Shapes;

namespace Auction_House_WPF.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class SecondChildView : UserControl
    {
        String userShowModel;

        public SecondChildView()
        {
            InitializeComponent();

            SecondChildViewModel sCWM = new SecondChildViewModel();
            userShowModel = sCWM.userShowModel.ToString();
            DataContext = sCWM; 
        }
    }
}