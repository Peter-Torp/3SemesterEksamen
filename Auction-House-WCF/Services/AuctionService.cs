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

        public List<ImageInfoData> GetImages(int auctionId)
        {
            AuctionController aCtr = new AuctionController();
            List<ImageInfoData> images = aCtr.GetImages(auctionId);
            return images;
        }

        public List<AuctionData> GetLatestAuctions()
        {
            AuctionController aCtr = new AuctionController();
            return aCtr.GetLatestAuctions();
        }

        public List<BidData> GetBids(int id)
        {
            BidController bCtr = new BidController();
            return bCtr.GetBids(id);
        }

        public bool InsertBid(BidData bidData)
        {
            BidController bCtr = new BidController();
            return bCtr.InsertBid(bidData);
        }

        public double GetMaxBidOnAuction(int auctionId)
        {
            BidController bCtr = new BidController();
            return bCtr.GetMaxBidOnAuction(auctionId);
        }

        public bool DeleteAuctionById(int id)
        {
            AuctionController aCtr = new AuctionController();
            return aCtr.DeleteAuction(id);
        }

        public List<AuctionData> GetAuctionByDesc(string auctionDesc)
        {
            AuctionController aCtr = new AuctionController();
            return aCtr.GetAuctionsByDesc(auctionDesc);
        }
    }
}
