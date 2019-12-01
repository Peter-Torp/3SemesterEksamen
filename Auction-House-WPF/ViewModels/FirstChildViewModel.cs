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



    }
}
