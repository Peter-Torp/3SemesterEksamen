using Auction_House_MVC.ModelLayer;
using Auction_House_MVC.ServiceLayer;
using Auction_House_MVC.ServiceLayer.AuctionServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.BusinessLayer
{
    public class B_AuctionController
    {
        public bool CreateAuction(CreateAuction createAuction /**IEnumerable<AuctionPicture> aP,**/) 
        {
            AuctionService aS = new AuctionService();

            return aS.InsertAuction(createAuction);
        }

        public Stream GetPicture(string userName)
        {
            AuctionService aS = new AuctionService();

            //Set up request
            DownloadRequest downloadRequest = new DownloadRequest();
            downloadRequest.FileName = "image_1.jpg";
            downloadRequest.AuctionNumber = 1;
            downloadRequest.UserId = 400;

            //Get stream from service.
            Stream rFI = aS.GetPicture(downloadRequest).FileByteStream;

            return rFI;
        }
    }
}