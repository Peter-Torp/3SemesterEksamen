using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Auction_House_WPF.Model
{
    public class UserShowModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        public UserShowModel(string _firstName, string _lastName, string _userName, string _address, string _email, string _phone, string _zipCode, string _dateOfBirth)
        {
            this.FirstName = _firstName;
            this.LastName = _lastName;
            this.UserName = _userName;
            this.Address = _address;
            this.Email = _email;
            this.Phone = _phone;
            this.Zipcode = _zipCode;
            this.DateofBirth = _dateOfBirth;

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