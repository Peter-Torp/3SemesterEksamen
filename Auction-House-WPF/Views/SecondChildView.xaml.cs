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

        //When textfield is entered. Mouse click. And get result. 
        private void ProfileSearchButton_MouseEnter(object sender, RoutedEventArgs e)
        {
            // EnterUsernameTextbox.Text += ((Button)sender).Content.ToString();
            if (EnterUsernameTextbox.Text != null)
            {
                string input = EnterUsernameTextbox.Text;
                sCWM.getUserByUserName(input);
            }
            else
            {
                MessageBox.Show("Searchfield is empty!");
            }
        }
    }

  
}