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
using ModelLayer;
using RepositoryLayer;

namespace Auction_House_WPF.ViewModels
{
    public class FirstChildViewModel : Screen, INotifyPropertyChanged
    {

        private AuctionRepos auctionRepos = new AuctionRepos();

        //Commands
        public RelayCommand DisplayAuctions { get; private set; }

        //Event
        public event PropertyChangedEventHandler PropertyChanged;
        

        //Constructor
        public FirstChildViewModel()
        {   
            //Instantiate Interface for repository. 
            AuctionShowModels = new ObservableCollection<AuctionShowModel>();
            DisplayAuctions = new RelayCommand(SearchAuction);
        }


        public void SearchAuction(string searchString)
        {
            foreach (AuctionModel auctionModel in auctionRepos.getAuctionsByUserName(searchString)) 
            {
                AuctionShowModels.Add(ConvertAuctionModelToAuctionShowModel(auctionModel));
            }


            
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

        public AuctionShowModel ConvertAuctionModelToAuctionShowModel(AuctionModel auctionModel)
        {
            AuctionShowModel auctionShowModel = new AuctionShowModel
                {
                    StartPrice = auctionModel.StartPrice,
                    BuyOutPrice = auctionModel.BuyOutPrice,
                    BidInterval = auctionModel.BidInterval,
                    StartDate = auctionModel.StartDate,
                    EndDate = auctionModel.EndDate,
                    Description = auctionModel.Description,
                    Category = auctionModel.Category
                };

            return auctionShowModel;
        }

        public ObservableCollection<AuctionShowModel> AuctionShowModels
        {
            get;
            set;
        }



    }
}
