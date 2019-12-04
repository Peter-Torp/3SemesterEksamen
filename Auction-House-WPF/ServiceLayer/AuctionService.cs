using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAuctionService = ServiceLayer.AuctionServiceReference.IAuctionService;
using Auction_House_WPF;
using ServiceLayer.AuctionServiceReference;
using Auction_House_WPF.ServiceAccessExceptions;
using ServiceLayer.Interface;
using ServiceLayer.Utility;

namespace Auction_House_WPF.ServiceLayer
{
    public class AuctionService : IAuctionServiceLayer
    {
        List<AuctionData> auctions;
        List<AuctionModel> auctionModels;

        public bool deleteAuctionById(int id)
        {
            


            throw new NotImplementedException();
        }

        public List<AuctionModel> getAuctionsByUserName(string userName)
        {
            IAuctionService auctionService = createServiceClient();
            auctions.Add(auctionService.GetActiveAuctionsByUsername(userName));

            foreach (AuctionData auction in auctions)
            {
                auctionModels.Add(AuctionUtility.convertAuctionDataToAuctionModel(auction));
            }

            return auctionModels;
        }

        private IAuctionService createServiceClient()
        {
            IAuctionService auctionService = null;
            try
            {
                auctionService = new AuctionServiceClient();

            }
            catch (ServiceAccessException)
            {
                throw new ServiceAccessException(ExceptionMessages.Couldnt_Instantiate_Service_Client);
            }

            return auctionService;
        }
    }
}
