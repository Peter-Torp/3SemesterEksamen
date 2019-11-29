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

        public void InsertPicture(RemoteFileInfo request)
        {
            throw new NotImplementedException();
        }

        public bool InsertPictures(List<ImageData> images)
        {
            throw new NotImplementedException();
        }
    }
}
