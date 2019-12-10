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
using Auction_House_WPF.Views;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Auction_House_WPF.ViewModels
{
    public class FirstChildViewModel : Screen, INotifyPropertyChanged
    {

        private AuctionRepos auctionRepos = new AuctionRepos();
        private FirstChildView View;

        //Commands
        public RelayCommand DisplayAuctions { get; private set; }
        public RelayCommand DeleteAuction { get; private set; }

        //Event
        public event PropertyChangedEventHandler PropertyChanged;
        

        //Constructor
        public FirstChildViewModel()
        {   
            //Instantiate Interface for repository. 
            AuctionShowModels = new ObservableCollection<AuctionShowModel>();
            DisplayAuctions = new RelayCommand(SearchAuction);
            DeleteAuction = new RelayCommand(OnDelete,CanDelete);
            FillDataGrid(); //fill datagrid with all auction when initialized
        }

        public void OnDelete()
        {
            auctionRepos.deleteAuctionById(SelectedAuction.Id);
            
        }
        public bool CanDelete()
        {
            return true;    
        }

        //Selet auction and delete.
        private AuctionShowModel _selectedAuction; 
        public AuctionShowModel SelectedAuction
        {
            get
            {
                return _selectedAuction; 
            }
            set
            {
                _selectedAuction = value; 
            }
        }


        public void SearchAuction(string searchString)
        {
                AuctionShowModels.Clear();
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
                    Id = auctionModel.Id,
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

        public void FillDataGrid()
        {
            AuctionShowModels.Clear();
            
            foreach(AuctionModel auctionModel in auctionRepos.GetAllAuctions())
            {
                AuctionShowModels.Add(ConvertAuctionModelToAuctionShowModel(auctionModel));
            }
   
        }

    }
}
