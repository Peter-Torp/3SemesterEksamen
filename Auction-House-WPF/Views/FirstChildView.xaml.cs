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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Auction_House_WPF.Views
{
    /// <summary>
    /// Interaction logic for FirstChildView.xaml
    /// </summary>
    public partial class FirstChildView : UserControl
    {
        public FirstChildView()
        {
            InitializeComponent();

            FirstChildViewModel firstViewModel = new FirstChildViewModel();
            DataContext = firstViewModel;
        }

        private void ProfileSearchButton_Click(object sender, RoutedEventArgs e)
        {
            EmptySearch();

        }

        public void EmptySearch()
        {
            if (String.IsNullOrEmpty(EnterUsernameTextbox.Text))
            {
                MessageBox.Show("Cannot be left empty, please input username", "Invalid search",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}