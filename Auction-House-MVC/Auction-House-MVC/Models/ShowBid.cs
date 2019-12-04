using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Models
{
    public class ShowBid
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string UserName { get; set; }
    }
}