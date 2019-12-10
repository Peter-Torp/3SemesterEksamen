using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class AuctionModel
    {
        public int Id { get; set; }
        public double StartPrice { get; set; }
        public double BuyOutPrice { get; set; }
        public double BidInterval { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Category { get; set; }
        public string UserName { get; set; }

        public AuctionModel(int id, double startPrice, double buyOutPrice, double bidInterval, string description, string startDate
            , string endDate, string category, string UserName)
        {
            this.Id = id;
            this.StartPrice = startPrice;
            this.BuyOutPrice = buyOutPrice;
            this.BidInterval = bidInterval;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Category = category;
        }


        





    }
}
