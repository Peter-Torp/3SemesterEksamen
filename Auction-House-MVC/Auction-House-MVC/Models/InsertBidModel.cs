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
        [Required]
        [DisplayName("Your bid")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        public int AuctionId {get; set;}
    }
}