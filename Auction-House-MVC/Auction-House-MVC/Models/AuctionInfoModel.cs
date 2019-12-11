using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Models
{
    public class AuctionInfoModel
    {
        public double StartPrice { get; set; }
        public double BuyOutPrice { get; set; }
        public double BidInterval { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Category { get; set; }
        public string UserName { get; set; }
        public int Id { get; set; }
        public double Bid { get; set; }
        public string UserLocation { get; set; }
    }
}