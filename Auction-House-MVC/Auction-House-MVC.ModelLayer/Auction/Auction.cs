using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_MVC.ModelLayer.Auction
{
    public class Auction
    {
        public Auction(int id, double startPrice, double buyOutPrice, double bidInterval,
            string description, DateTime startDate, DateTime endDate, string category)
        {
            Id = id;
            StartPrice = startPrice;
            BuyOutPrice = buyOutPrice;
            BidInterval = bidInterval;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Category = category;
        }

        public int Id { get; set; }
        public double StartPrice { get; set; }
        public double BuyOutPrice { get; set; }
        public double BidInterval { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Category { get; set; }
        public string UserName { get; set; }
        public string ZipCode { get; set; }
        public string Region { get; set; }
    }
}
