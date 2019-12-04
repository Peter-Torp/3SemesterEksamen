using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_MVC.ModelLayer.Bid
{
    public class Bid
    {
        public int Bid_Id { get; set; }
        public int Auction_Id { get; set; }
        public int User_Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string UserName { get; set; }
    }
}
