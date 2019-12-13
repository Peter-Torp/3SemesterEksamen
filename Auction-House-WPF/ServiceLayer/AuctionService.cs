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
using Auction_House_WPF.ModelLayer;

namespace Auction_House_WPF.ServiceLayer
{
    public class AuctionService : IAuctionServiceLayer
    {

        public AuctionService()
        {
            
        }
        

        public void DeleteAuctionById(int id)
        {
            using (AuctionServiceClient proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService"))
            {

                proxy.DeleteAuctionById(id);

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

        //for test purposes for now.
        public void CreateAuction(AuctionModel auctionModel, UserModel userModel)
        {

            using (AuctionServiceClient proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService"))

                proxy.InsertAuction(AuctionUtility.ConvertAuctionModelToAuctionData(auctionModel, userModel));

            
        }


     }
}
