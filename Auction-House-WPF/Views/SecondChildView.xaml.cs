using Auction_House_WPF.Model;
using Auction_House_WPF.ViewModels;
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
using System.Windows.Shapes;

namespace Auction_House_WPF.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class SecondChildView : UserControl
    {
        
        SecondChildViewModel sCWM;

        public SecondChildView()
        {
            InitializeComponent();

            sCWM = new SecondChildViewModel();
            DataContext = sCWM; 
        }

        private void ProfileSearchButton_Click(object sender, RoutedEventArgs e)
        {
            EmptySearch();
        }


        //Error Handling to Nothing entered
        public void EmptySearch()
        {
            if (string.IsNullOrEmpty(EnterUsernameTextbox.Text))
            {
                MessageBox.Show("Cannot be left empty, please input username", "Invalid search",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UserGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object SelectedUser = e.AddedItems;
            sCWM.GetUserAuctions(SelectedUser);
        }
    }

  
}