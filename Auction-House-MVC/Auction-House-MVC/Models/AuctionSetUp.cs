using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Models
{
    public class AuctionSetUp
    {
        public double StartPrice { get; set; }
        public double BuyOutPrice { get; set; }
        public double BidInterval { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }
        public string Category { get; set; }

    }
}