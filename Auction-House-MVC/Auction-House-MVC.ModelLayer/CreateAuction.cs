using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.ModelLayer
{
    public class CreateAuction
    {
        public string UserName { get; set; }
        public double StartPrice { get; set; }
        public double BuyOutPrice { get; set; }
        public double BidInterval { get; set; }
        public string Description { get; set; }
        public DateTime EndDate {get;set;}
        public string Category { get; set; }
    }
}