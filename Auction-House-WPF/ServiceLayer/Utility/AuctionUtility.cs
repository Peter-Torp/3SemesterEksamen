using Auction_House_WPF.ModelLayer;
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
        public static AuctionModel ConvertAuctionDataToAuctionModel(AuctionData auction)
        {
            //Id,StartPrice,BuyOutPrice,BidInterval,Description,StartDate,EndDate,Category

            AuctionModel auctionModel = new AuctionModel()
            {
                Id = auction.Id,
                StartPrice = auction.StartPrice,
                BuyOutPrice = auction.BuyOutPrice,
                BidInterval = auction.BidInterval,
                Description = auction.Description,
                StartDate = auction.StartDate,
                EndDate = auction.EndDate,
                Category = auction.Category,
                UserName = auction.UserName

            };
            return auctionModel;
        }

        public static List<AuctionModel> ConvertArrayToList(AuctionData[] auctions)
        {
            List<AuctionModel> auctionDatas = new List<AuctionModel>();
            foreach (AuctionData auctionData in auctions)
            {
                auctionDatas.Add(ConvertAuctionDataToAuctionModel(auctionData));
            }

            return auctionDatas;
        }

        //Convert auctionModel to AuctionData. For creating a auction.
        internal static AuctionData ConvertAuctionModelToAuctionData(AuctionModel auctionModel, UserModel userModel)
        {
            AuctionData auctionData = new AuctionData
            {
                Id = auctionModel.Id,
                StartPrice = auctionModel.StartPrice,
                BuyOutPrice = auctionModel.BuyOutPrice,
                BidInterval = auctionModel.BidInterval,
                Description = auctionModel.Description,
                StartDate = auctionModel.StartDate,
                EndDate = auctionModel.EndDate,
                Category = auctionModel.Category,
                UserName = auctionModel.UserName,
                UserId = userModel.User_Id
            };

            return auctionData;
        }



    }
}
