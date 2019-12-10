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

        public AuctionService()
        {
            
        }
        

        public bool DeleteAuctionById(int id)
        {
            using (AuctionServiceClient proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService"))
            {
                bool deleted = false;

                proxy.DeleteAuctionById(id);

                if (GetAuctionById(id) == null)
                {
                    deleted = true;
                } else
                {
                    deleted = false;
                }

                return deleted;
            }

        }

        public AuctionModel GetAuctionById(int id)
        {
            using (AuctionServiceClient proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService"))
            {
                return AuctionUtility.ConvertAuctionDataToAuctionModel(proxy.GetAuction(id));
            }
        }


        public List<AuctionModel> GetAuctionsByUserName(string userName)
        {

            using (AuctionServiceClient proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService"))
            {
                return AuctionUtility.ConvertArrayToList(proxy.GetUserAuctions(userName));

            }
        }

        public List<AuctionModel> GetAllAuctions()
        {
            using (AuctionServiceClient proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService"))
            {
                return AuctionUtility.ConvertArrayToList(proxy.GetAllAuctions());
            }
            
        }
     }
}
