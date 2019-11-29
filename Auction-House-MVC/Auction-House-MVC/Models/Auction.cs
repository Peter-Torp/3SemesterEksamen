using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Models
{
    public class Auction
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public double BuyOut { get; set; }
        public double Bidding { get; set; }
        public double Price { get; set; }
        public int Date { get; set; }
    }
}