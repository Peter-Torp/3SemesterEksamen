using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WPF.Model
{
    public class AuctionShowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AuctionShowModel(int id, int startPrice, int buyOutPrice, int bidInterval, string description, DateTime startDate,
            DateTime endDate, string category, string userName)
        {
            this.Id = id;
            this.StartPrice = startPrice;
            this.BuyOutPrice = buyOutPrice;
            this.BidInterval = bidInterval;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Category = category;
            this.UserName = userName;
        }

        public AuctionShowModel()
        {

        }

        public int Id { get; set; }
        public double StartPrice{ get; set; }
        public double BuyOutPrice { get; set; }
        public double BidInterval { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Category { get; set; }
        public string UserName { get; set; }

        public int User_Id { get; set; }
    }
}
