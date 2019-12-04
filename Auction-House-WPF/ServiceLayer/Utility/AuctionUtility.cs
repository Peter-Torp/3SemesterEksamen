using ModelLayer;
using ServiceLayer.AuctionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Utility
{
    static class AuctionUtility
    {
        public static AuctionModel convertAuctionDataToAuctionModel(AuctionData auction)
        {
            //Id,StartPrice,BuyOutPrice,BidInterval,Description,StartDate,EndDate,Category

            AuctionModel auctionModel = new AuctionModel(0, 0, 0, 0, null, null, null, null)
            {
                Id = auction.Id,
                StartPrice = auction.StartPrice,
                BuyOutPrice = auction.BuyOutPrice,
                BidInterval = auction.BidInterval,
                Description = auction.Description,
                StartDate = auction.StartDate.ToString(),
                EndDate = auction.EndDate.ToString(),
                Category = auction.Category

            };
            return auctionModel;
        }



    }
}
