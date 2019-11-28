using Auction_House_MVC.ModelLayer;
using Auction_House_MVC.ModelLayer.Auction;
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

        public Stream GetPicture(string userName, int auctionId)
        {
            //Get user ID to get folder destination.
            B_UserController bUCtr = new B_UserController();
            User user = bUCtr.GetUserByUserName(userName);

            //Get Auction ID to get folder destination.


            //Set up request
            DownloadRequest downloadRequest = new DownloadRequest();
            downloadRequest.FileName = "image_1.jpg";
            downloadRequest.AuctionNumber = auctionId;
            downloadRequest.UserId = user.Id;

            //Get stream from service.
            AuctionService aS = new AuctionService();
            Stream rFI = aS.GetPicture(downloadRequest).FileByteStream;

            return rFI;
        }

        public List<Image> GetAllPictures()
        {
            throw new NotImplementedException();
        }

        public bool InsertPictures()
        {
            throw new NotImplementedException();
        }


    }
}