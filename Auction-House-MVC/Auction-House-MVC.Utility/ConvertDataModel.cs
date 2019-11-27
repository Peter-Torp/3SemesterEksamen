using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction_House_MVC.ModelLayer;
using Auction_House_MVC.ServiceLayer.UserServiceReference;

namespace Auction_House_MVC.Utility
{
    public class ConvertDataModel : IDataModel
    {



        public CreateAuction ConvertFromAuctionSetUPToCreateAuction(AuctionSetUp aSU, string userName)
        {
            CreateAuction cA = new CreateAuction
            {
                UserName = userName,
                StartPrice = aSU.StartPrice,
                BuyOutPrice = aSU.BuyOutPrice,
                BidInterval = aSU.BidInterval,
                Description = aSU.Description,
                EndDate = aSU.EndDate,
                Category = aSU.Category
            };
            return cA;
        }
    }
}