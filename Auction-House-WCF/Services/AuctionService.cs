using Auction_House_WCF.Controllers;
using Auction_House_WCF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Services
{
    class AuctionService : IAuctionService
    {
        public AuctionData GetActiveAuctionsByUsername(string userName)
        {
            throw new NotImplementedException();
        }


        public AuctionData GetDoneAuctionsByUsername(string userName)
        {
            throw new NotImplementedException();
        }

        public RemoteFileInfo GetPicture(DownloadRequest request)
        {
            AuctionController aCtr = new AuctionController();
            return aCtr.GetPicture(request);
        }

        public int InsertAuction(AuctionData aData)
        {
            AuctionController aCtr = new AuctionController();

            return aCtr.InsertAuction(aData);
        }

        public void InsertPicture(ImageData image)
        {
            AuctionController aCtr = new AuctionController();

            aCtr.InsertPicture(image);
        }

        public bool InsertPictures(List<ImageData> images)
        {
            AuctionController aCtr = new AuctionController();

            return aCtr.InsertPictures(images);
        }

        public List<AuctionData> GetAuctions(string auctionName)
        {
            AuctionController aCtr = new AuctionController();
            return aCtr.GetAuctions(auctionName);
        }

        public List<AuctionData> GetUserAuctions(string userName)
        {
            AuctionController aCtr = new AuctionController();
            return aCtr.GetUserAuctions(userName);
        }

        public AuctionData GetAuction(int auctionId)
        {
            AuctionController aCtr = new AuctionController();
            return aCtr.GetAuction(auctionId);
        }

        public List<string> GetCategories()
        {
            AuctionController aCtr = new AuctionController();
            return aCtr.GetCategories();
        }

        public List<ImageData> GetImages(int auctionId)
        {
            AuctionController aCtr = new AuctionController();
            return aCtr.GetImages(auctionId);
        }
    }
}
