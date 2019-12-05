using Auction_House_MVC.ModelLayer;
using Auction_House_MVC.ModelLayer.Auction;
using Auction_House_MVC.ModelLayer.Bid;
using Auction_House_MVC.ServiceLayer.AuctionServiceReference;
using Auction_House_MVC.ServiceLayer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Auction_House_MVC.ServiceLayer
{
    public class AuctionService
    {
        public bool InsertAuction(CreateAuction createAuction)
        {
            IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService");

            ConvertDataModel converter = new ConvertDataModel();

            bool confirmed = false;

            int id = aSClient.InsertAuction(converter.ConvertFromCreateAuctionToAuctionData(createAuction));

            if (id != -1)
            {
                confirmed = true;
            }
            return confirmed;
        }

        public Image GetPicture(DownloadRequest downloadRequest)
        {
            // Use streaming endpoint. Because images = larger files.
            IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService_Streaming");

            ConvertDataModel converter = new ConvertDataModel();

            return converter.ConvertRemoteFileInfoToImage(aSClient.GetPicture(downloadRequest));

        }

        public void InsertPicture(Image image)
        {
            IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService_Streaming");

            ConvertDataModel converter = new ConvertDataModel();

            aSClient.InsertPicture(converter.ConvertFromImageToImageData(image));
        }

        public bool InsertPictures(List<Image> images)
        {
            IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService_Streaming");

            ConvertDataModel converter = new ConvertDataModel();

            // Convert to old array for sending over WCF.
            ImageData[] imageData = converter.ConvertFromImagesToImageData(images);

            return aSClient.InsertPictures(imageData);
        }

        public List<Auction> GetUserAuctions(string userName)
        {
            IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService");

            ConvertDataModel converter = new ConvertDataModel();

            //Convert from basic array to c# generic array
            return converter.ConvertFromAuctionDataToAuctions(aSClient.GetUserAuctions(userName));
        }

        public Auction GetAuction(int auctionId)
        {
            IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService");

            ConvertDataModel converter = new ConvertDataModel();

            return converter.ConvertFromAuctionDataToAuction(aSClient.GetAuction(auctionId));
        }

        ////public List<CreateAuction> ShowAuctions(string auctionName)
        //{
        //    IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService");

        //    ConvertDataModel converter = new ConvertDataModel();

        //    }

        public List<string> GetCategories()
        {
            IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService");

            ConvertDataModel converter = new ConvertDataModel();

            return converter.ConvertFromBasicArrayToGenericArray(aSClient.GetCategories());
        }

        public List<Image> GetImages(int auctionId)
        {
            IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService");

            ConvertDataModel converter = new ConvertDataModel();

            List<Image> images = converter.ConvertFromImageInfoDataToImages(aSClient.GetImages(auctionId));

            return images;
        }

        public List<Auction> GetLatestAuctions()
        {
            IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService");

            ConvertDataModel converter = new ConvertDataModel();

            return converter.ConvertFromAuctionDataToAuctions(aSClient.GetLatestAuctions());
        }

        public List<Bid> GetBids(int auctionId)
        {
            IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService");

            ConvertDataModel converter = new ConvertDataModel();

            return converter.ConvertFromBidDataToBids(aSClient.GetBids(auctionId));
        }

        public int InsertBid(Bid bid)
        {
            IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService");

            ConvertDataModel converter = new ConvertDataModel();

            return aSClient.InsertBid(converter.ConvertFromBidToBidData(bid));
        }

        public double GetHighestBidOnAuction(int auctionId)
        {
            IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService");

            return aSClient.GetMaxBidOnAuction(auctionId);
        }

    }
}
