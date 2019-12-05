using Auction_House_MVC.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Models
{
    public class InsertBidModel
    {
        public double MinimumValidBid { get; set; }
        public double CurrentHighestBid { get; set; }
        [Required]
        [DisplayName("Your bid")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        public int AuctionId {get; set;}

        public double SetRange()
        {
            
            return 0;
        }
    }
}