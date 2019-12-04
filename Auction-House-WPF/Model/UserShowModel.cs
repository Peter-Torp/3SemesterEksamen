using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Auction_House_WPF.ModelLayer;
using System.Collections.ObjectModel;

namespace Auction_House_WPF.Model
{

    public class UserShowModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public string DateOfBirth { get; set; }


        public override string ToString()
        {
            return FirstName + LastName + UserName + Address + Email + Phone + ZipCode + DateOfBirth;
             
        }


    }
}