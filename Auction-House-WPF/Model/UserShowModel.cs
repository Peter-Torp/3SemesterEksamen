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
        List<AuctionShowModel> Auctions = new List<AuctionShowModel>(); 

        public UserShowModel(string userName, string address, string email, string phone, string zipCode)
        {
            this.UserName = userName;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.ZipCode = zipCode;
        }

        public UserShowModel()//2nd constructor
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }

        public void AddAuctions(AuctionShowModel auction)
        {
            Auctions.Add(auction);
        }

        public override string ToString()
        {
            return FirstName + LastName + UserName + Address + Email + Phone + ZipCode;
             
        }


    }
}