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

        public Auction GetAuction(int auctionId)
        {
            AuctionService aS = new AuctionService();

            return aS.GetAuction(auctionId);
        }

        public void InsertPicture(Image image, string userName, int auctionId)
        {
            AuctionService aS = new AuctionService();

            B_UserController uBCtr = new B_UserController();

            int userId = uBCtr.GetUserByUserName(userName).Id;

            image.AuctionId = auctionId;
            image.UserId = userId;

            aS.InsertPicture(image);

        }

        public bool InsertPictures(List<Image> images, string userName, int auctionId)
        {
            AuctionService aS = new AuctionService();

            B_UserController uBCtr = new B_UserController();

            int userId = uBCtr.GetUserByUserName(userName).Id;

            foreach(Image image in images)
            {
                image.AuctionId = auctionId;
                image.UserId = userId;
            };

            bool successful = aS.InsertPictures(images);
            return successful;
        }

        public List<Auction> GetUserAuctions(string userName)
        {
            AuctionService aS = new AuctionService();

            return aS.GetUserAuctions(userName);
        }

        //public List<CreateAuction> ShowAuctions(string auctionName)
        //{
        //    AuctionService aS = new AuctionService();
        //    return aS.ShowAuctions(auctionName);
        //}
    }
}