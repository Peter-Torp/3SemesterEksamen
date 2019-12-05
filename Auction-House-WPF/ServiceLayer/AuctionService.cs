using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.AuctionServiceReference;
using Auction_House_WPF.ServiceAccessExceptions;
using ServiceLayer.Interface;
using ServiceLayer.Utility;

namespace Auction_House_WPF.ServiceLayer
{
    public class AuctionService : IAuctionServiceLayer
    {
        List<object> auctions;
        List<AuctionModel> auctionModels;

        public AuctionService()
        {
            auctions = new List<object>();
            auctionModels = new List<AuctionModel>();
        }
        

        public bool deleteAuctionById(int id)
        {
            


            throw new NotImplementedException();
        }

        public List<AuctionModel> getAuctionsByUserName(string userName)
        {
            auctionModels.Clear();
            auctions.Clear();
            AuctionData auctionData;

            using(AuctionServiceClient proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService"))
            {
                auctions.Add(proxy.GetUserAuctions(userName));

                    foreach (object auction in auctions)
                {
                    auctionData = (AuctionData)auction;
                    auctionModels.Add(AuctionUtility.convertAuctionDataToAuctionModel(auctionData));
                }
            }

            return auctionModels;
        }
        /*
        private IAuctionService CreateServiceClient()
        {
            IAuctionService auctionService = null;

            try
            {
                auctionService = new AuctionServiceClient("BasicHttpBinding_IAuctionService");

            }
            catch (ServiceAccessException)
            {
                throw new ServiceAccessException(ExceptionMessages.Couldnt_Instantiate_Service_Client);
            }

            return auctionService;
        }*/
    }
}
