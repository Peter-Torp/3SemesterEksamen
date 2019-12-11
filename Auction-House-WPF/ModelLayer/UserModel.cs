using ModelLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WPF.ModelLayer
{
    public class UserModel : INotifyPropertyChanged
    {
        List<AuctionModel> Auctions = new List<AuctionModel>();

        public UserModel(string firstName, string lastName, string userName, string address, string email, string phone, string zipCode, string dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = userName;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.Zipcode = zipCode;
            this.DateofBirth = dateOfBirth;
            

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Zipcode { get; set; }

        public string DateofBirth { get; set; }
        public int User_Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
