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
        }

        private void ProfileSearchButton_Click(object sender, RoutedEventArgs e)
        {
            //FirstChildViewModel firstchildmodelview = new FirstChildViewModel();
            //firstchildmodelview.InsertDummyPerson();
            //firstchildmodelview.Refresh();

            FirstNameTextblock.Text = "Christ";
            LastNameTextblock.Text = "McDutten";
            UsernameTextblock.Text = "OkBoomer";
            AddressTextblock.Text = "ZoomerTown";
            EmailTextblock.Text = "IAmNotADoomer@NotDoomer.cn";
            PhoneTextblock.Text = "133769420";
            ZipcodeTextblock.Text = "6969";
            DateofBirthTextblock.Text = "420/69/666";
        }
    }
}