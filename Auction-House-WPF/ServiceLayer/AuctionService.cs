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
        

        public bool deleteAuctionById(int id)
        {
            


            throw new NotImplementedException();
        }

        public List<AuctionModel> getAuctionsByUserName(string userName)
        {

            using (AuctionServiceClient proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService"))
            {
                return AuctionUtility.ConvertArrayToList(proxy.GetUserAuctions(userName));

            }
        }
     }
}
