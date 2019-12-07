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

        public int Id { get; set; }
        public double StartPrice{ get; set; }
        public double BuyOutPrice { get; set; }
        public double BidInterval { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Category { get; set; }
    }
}
