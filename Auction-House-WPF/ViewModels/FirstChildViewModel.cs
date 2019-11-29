using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Auction_House_WPF.Model;
using Auction_House_WPF.RepositoryLayer.Interface;
using Auction_House_WPF.Repository;

namespace Auction_House_WPF.ViewModels
{
    public class FirstChildViewModel : Screen, INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _address;
        private string _email;
        private string _phone;
        private string _zipcode;
        private string _dateOfBirth;

        private ObservableCollection<UserShowModel> _retrievedModel;
        private readonly List<UserShowModel> results;
        private UserShowModel SelectedModel;
        private IUserRepos IUserRepos;  

        public event PropertyChangedEventHandler PropertyChanged;
        

        //Constructor
        public FirstChildViewModel()
        {   
            //Instantiate Interface for repository. 
            IUserRepos = new UserRepos();
        }

        //public ICommand SearchUserCommand
        //{
        //    get
        //    {
        //        if (_searchCommand == null)
        //        {
        //            _searchCommand = new RelayCommand(
        //                param => Search()
        //                );
        //        }
        //    }
        //    return _searchCommand;
        //}




        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName); //CopyPaste this where a value changes? - Listens to if something changes
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName); //CopyPaste this where a value changes? - Listens to if something changes
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName); //CopyPaste this where a value changes? - Listens to if something changes
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
                NotifyOfPropertyChange(() => Address); //CopyPaste this where a value changes? - Listens to if something changes
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email); //CopyPaste this where a value changes? - Listens to if something changes
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                _phone = value;
                NotifyOfPropertyChange(() => Phone); //CopyPaste this where a value changes? - Listens to if something changes
            }
        }

        public string Zipcode
        {
            get
            {
                return _zipcode;
            }

            set
            {
                _zipcode = value;
                NotifyOfPropertyChange(() => Zipcode); //CopyPaste this where a value changes? - Listens to if something changes
            }
        }

        public string DateofBirth
        {
            get
            {
                return _dateOfBirth;
            }

            set
            {
                _dateOfBirth = value;
                NotifyOfPropertyChange(() => DateofBirth); //CopyPaste this where a value changes? - Listens to if something changes
            }
        }


        internal ObservableCollection<UserShowModel> RetrievedModel
        {
            get
            {
                return _retrievedModel;
            }
            set
            {
                _retrievedModel = value;
                OnPropertyChanged("RetrievedModel");
            }

        }

        /* internal PersonModel Search(string userName)
         {
             IUserRepos uR = new UserRepos();
             PersonModel user = null;
             if (userName != null)
             {
                 user = uR.GetUserByUserName(userName);
             }
             else
             {
                 Console.WriteLine("User name wasent entered. Try again!");
             }
             return user;
         }*/

        internal void Search(string userName)
        {
            var foundUser = IUserRepos.GetUserByUserName(userName);

            new UserShowModel(null,null,foundUser.Username,foundUser.Address,foundUser.Email,foundUser.Phone,foundUser.Zipcode,foundUser.DateofBirth);

            RetrievedModel = new ObservableCollection<UserShowModel>(results);

        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void InsertDummyPerson()
        {
            _firstName = "George Jensen";
            _lastName = "McDutten";
            _userName = "OkBoomer";
            _address = "ZoomerTown";
            _email = "IAmNotADoomer@NotDoomer.cn";
            _phone = "133769420";
            _zipcode = "6969";
            _dateOfBirth = "420/69/666";

        }

    }
}
