using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Models
{
    public class AuctionModel
    {
        public AuctionInfoModel AuctionInfoModel { get; set; }
        public List<ShowAuctionPictureModel> ShowAuctionPictureModels { get; set; }
        public List<ShowBid> ShowBids { get; set; }
        public InsertBidModel InsertBidModel {get; set;}
    }
}