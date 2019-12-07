using Auction_House_MVC.ModelLayer;
using Auction_House_MVC.ModelLayer.Auction;
using Auction_House_MVC.ModelLayer.Bid;
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

        public Image GetPicture(string userName, int auctionId, string fileName)
        {
            //Get user ID to get folder destination.
            B_UserController bUCtr = new B_UserController();
            User user = bUCtr.GetUserByUserName(userName);

            //Get Auction ID to get folder destination.


            //Set up request
            DownloadRequest downloadRequest = new DownloadRequest();
            downloadRequest.FileName = fileName;
            downloadRequest.AuctionNumber = auctionId;
            downloadRequest.UserId = user.Id;

            //Get stream from service.
            AuctionService aS = new AuctionService();
            Image image = aS.GetPicture(downloadRequest);

            return image;
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

        public List<string> GetCategories()
        {
            AuctionService aS = new AuctionService();

            return aS.GetCategories();
        }

        public List<Image> GetImages(int auctionId)
        {
            AuctionService aS = new AuctionService();

            return aS.GetImages(auctionId);
        }

        public List<Auction> GetLatestAuctions()
        {
            AuctionService aS = new AuctionService();

            return aS.GetLatestAuctions();

        }
        public List<Bid> GetBids(int auctionId)
        {
            AuctionService aS = new AuctionService();
            return aS.GetBids(auctionId);
        }

        public bool InsertBid(Bid bid)
        {
            AuctionService aS = new AuctionService();

            bool successful = aS.InsertBid(bid);

            return successful;
        }

        public double GetHighestBidOnAuction(int auctionId)
        {
            AuctionService aS = new AuctionService();

            double hBid = aS.GetHighestBidOnAuction(auctionId);
            if(hBid == 0)
            {
                Auction auction = aS.GetAuction(auctionId);
                hBid = auction.StartPrice;
            }

            return hBid;
        }
    }
}