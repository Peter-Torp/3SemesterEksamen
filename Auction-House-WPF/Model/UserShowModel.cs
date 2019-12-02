using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Auction_House_WPF.ModelLayer;

namespace Auction_House_WPF.Model
{
    public class UserShowModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        public UserShowModel(UserModel user)
        {
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.UserName = user.Username;
            this.Address = user.Address;
            this.Email = user.Email;
            this.Phone = user.Phone;
            this.Zipcode = user.Zipcode;
            this.DateofBirth = user.DateofBirth;

        }

        public string FirstName
        {
            get
            {
                return FirstName;
            }

            set
            {
                if (value != this.FirstName)
                {
                    this.FirstName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get
            {
                return LastName;
            }

            set
            {
                if (value != this.LastName)
                {
                    this.LastName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string UserName
        {
            get
            {
                return UserName;
            }

            set
            {
                if (value != this.UserName)
                {
                    this.UserName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Address
        {
            get
            {
                return Address;
            }

            set
            {
                if (value != this.Address)
                {
                    this.Address = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Email
        {
            get
            {
                return Email;
            }

            set
            {
                if (value != this.Email)
                {
                    this.Email = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Phone
        {
            get
            {
                return Phone;
            }

            set
            {
                if (value != this.Phone)
                {
                    this.Phone = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Zipcode
        {
            get
            {
                return Zipcode;
            }

            set
            {
                if (value != this.Zipcode)
                {
                    this.Zipcode = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string DateofBirth
        {
            get
            {
                return DateofBirth;
            }

            set
            {
                
                if (value != this.DateofBirth)
                {
                    this.DateofBirth = value;
                    NotifyPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return FirstName + LastName + UserName + Address + Email + Phone + Zipcode + DateofBirth;
             
        }


    }
}