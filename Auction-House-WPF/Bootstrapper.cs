using Auction_House_WPF.ViewModel;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Auction_House_WPF
{
    //This is our starting point for our application - caliburn is designed to handle a bootstrapper
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        //We're overriding OnStartUp event instead of the default one
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //ShellViewModel is default template window like MainWindow for mvvm
            DisplayRootViewFor<ShellViewModel>(); //Instead of MainWindow we use ShellViewModel
        }
    }
}