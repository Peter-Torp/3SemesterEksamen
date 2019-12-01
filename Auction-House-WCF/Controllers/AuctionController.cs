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


        public bool InsertPicture(ImageData image)
        {
            ImageHandler iHandler = new ImageHandler();

            return iHandler.InsertPictureToFolder(image);
        }
        
        public RemoteFileInfo GetPicture(DownloadRequest request)
        {
            RemoteFileInfo rFI = new RemoteFileInfo();
            try
            {
                string appDirectory = @"C:\Users\Martin\source\repos\Auction-House-V2\Auction-House-WCF\"; // AppDomain.CurrentDomain.BaseDirectory
                string baseDirectory = @"Images\Auctions\";
                string fullDirectory = appDirectory + baseDirectory + request.UserId + @"\" + request.AuctionNumber + @"\" + request.FileName;
                bool fileExist = File.Exists(fullDirectory);
                if (fileExist)
                {
                    FileStream imgFile = File.OpenRead(fullDirectory);
                    rFI.FileByteStream = imgFile;
                    return rFI;
                }
                else
                {
                    throw new FileNotFoundException("File not found at: " + fullDirectory, request.FileName);
                }
            }
            catch (IOException exp)
            {
                throw exp;
            }
        }

        internal List<AuctionData> GetAuctions(string auctionName)
        {
            DBAuction dBAuction = new DBAuction();
            return dBAuction.GetAuctions(auctionName);
        }


    }
}
