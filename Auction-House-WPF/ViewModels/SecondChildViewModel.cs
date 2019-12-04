using Auction_House_WPF.Model;
using Auction_House_WPF.ModelLayer;
using Auction_House_WPF.Repository;
using Auction_House_WPF.Views;
using Caliburn.Micro;
using MySys = System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Auction_House_WPF.ViewModels
{
    public class SecondChildViewModel : Screen
    {
        UserRepos userRepos = new UserRepos();
        SecondChildView secondChildView;
        public RelayCommand DisplayUserInfo { get; private set; }
        public MessageCommand DisplayMessageCommand { get; private set; }

        public SecondChildViewModel()
        {
           // DisplayMessageCommand = new MessageCommand(Display);
            DisplayUserInfo = new RelayCommand(SearchUserByUserName);
            UserShowModel = new ObservableCollection<UserShowModel>();
            
        }
        public void Display(string message)
        {
            MessageBox.Show(message);
        }
        
        //Search the user in the database and convert it to a UserShowModel and return the user.
        public void SearchUserByUserName(string searchString)
        {
            UserShowModel.Add(ConvertUserModelToUserShowModel(userRepos.GetUserByUserName(searchString)));
            
        }

        /*
         * Convert UserModel type to UserShowModel type. 
         * */
        public UserShowModel ConvertUserModelToUserShowModel(UserModel user)
        {
            UserShowModel userShowModel = new UserShowModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                UserName = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                ZipCode = user.Zipcode,
                DateOfBirth = user.DateofBirth
                
            };

            return userShowModel;
        }

        public ObservableCollection<UserShowModel> UserShowModel
        {
            get;
            set;            
        }


    }


}