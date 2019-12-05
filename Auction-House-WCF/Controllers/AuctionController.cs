using Auction_House_WCF.DataAccess;
using Auction_House_WCF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Controllers
{
    public class AuctionController
    {
        public int InsertAuction(AuctionData auctionData)
        {
            DBAuction auctionDB = new DBAuction();

            // Set start date for the auction.
            auctionData.StartDate = DateTime.Now;

            return auctionDB.Create(auctionData);
        }

        public bool InsertPictures(List<ImageData> images)
        {
            DBAuction auctionDB = new DBAuction();

            //Set the dates.
            foreach(ImageData image in images)
            {
                image.DateAdded = DateTime.Now;
                image.ImgUrl = image.UserId.ToString() + @"\" + image.AuctionId.ToString();
            }

            return auctionDB.InsertPictures(images);
        }

        public List<AuctionData> GetUserAuctions(string userName)
        {
            DBAuction dBAuction = new DBAuction();

            return dBAuction.GetUserAuctions(userName);
        }

        public AuctionData GetAuction(int auctionId)
        {
            DBAuction dBAuction = new DBAuction();

            return dBAuction.Get(auctionId);
        }

        public List<string> GetCategories() 
        {
            DBAuction dBAuction = new DBAuction();

            return dBAuction.GetCategory();
        }

        public List<AuctionData> GetLatestAuctions()
        {
            DBAuction dBAuction = new DBAuction();

            return dBAuction.GetLastestAuctions();
        }


        public bool InsertPicture(ImageData image)
        {
            //ImageHandler iHandler = new ImageHandler();

            //TEST
            DBAuction dBAuction = new DBAuction();

            //Add URL
            image.ImgUrl = Path.Combine(image.UserId.ToString(), image.AuctionId.ToString());

            //Add server date
            image.DateAdded = DateTime.Now;

            List<ImageData> images = new List<ImageData>();
            images.Add(image);

            return dBAuction.InsertPictures(images);

            //return iHandler.InsertPictureToFolder(image);
        }
        
        public RemoteFileInfo GetPicture(DownloadRequest request)
        {
            ImageHandler iHandler = new ImageHandler();

            return iHandler.GetPicture(request);
        }

        internal List<AuctionData> GetAuctions(string auctionName)
        {
            DBAuction dBAuction = new DBAuction();
            return dBAuction.GetAuctions(auctionName);
        }

        public List<ImageInfoData> GetImages(int auctionId)
        {
            DBAuction dBAuction = new DBAuction();
            return dBAuction.GetImages(auctionId);
        }


    }
}
