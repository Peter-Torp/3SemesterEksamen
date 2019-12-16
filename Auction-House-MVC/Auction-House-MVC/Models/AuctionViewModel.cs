using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Models
{
    public class AuctionViewModel
    {
        public AuctionInfoViewModel AuctionInfoModel { get; set; }
        public List<PictureViewModel> PictureViewModels { get; set; }
        public List<BidViewModel> ShowBids { get; set; }
        public InsertBidModel InsertBidModel {get; set;}
    }
}