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
using System.Windows.Controls;
using RepositoryLayer;
using ModelLayer;

namespace Auction_House_WPF.ViewModels
{
    public class SecondChildViewModel : Screen
    {
        UserRepos userRepos = new UserRepos();
        AuctionRepos auctionRepos = new AuctionRepos();
        SecondChildView SecondChildView;
        FirstChildViewModel FirstChildViewModel;
        public RelayCommand DisplayUserInfo { get; private set; }
        public MessageCommand DisplayMessageCommand { get; private set; }
        public RelayCommand DeleteAuction { get; private set; }

        public SecondChildViewModel()
        {
           // DisplayMessageCommand = new MessageCommand(Display);
            DisplayUserInfo = new RelayCommand(SearchUserByUserName);
            UserShowModel = new ObservableCollection<UserShowModel>();
            AuctionShowModel = new ObservableCollection<AuctionShowModel>();
            DeleteAuction = new RelayCommand(OnDelete,CanDelete);
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

        //Find the associated auctions for a user
        public void GetUserAuctions(UserShowModel user)
        {
            AuctionShowModel.Clear();
            foreach (AuctionModel auctionModel in auctionRepos.getAuctionsByUserName(user.UserName))
            {
                AuctionShowModel.Add(FirstChildViewModel.ConvertAuctionModelToAuctionShowModel(auctionModel));
            }
        }

        //Set the propterties when an auction is selected
        public AuctionShowModel SelectedAuction
        {
            get;
            set;
        }


        //Delete the selected auction -> SelectedAuction
        public void OnDelete()
        {
            auctionRepos.deleteAuctionById(SelectedAuction.Id);
        }

        //Can delete. If not. Button is unavailable
        public bool CanDelete()
        {
            return true;    //not in use
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

        public ObservableCollection<AuctionShowModel> AuctionShowModel
        {
            get;
            set;
        }


    }


}