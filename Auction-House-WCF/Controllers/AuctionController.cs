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

        public void InsertPictures(List<ImageData> images, Stream imageStream)
        {
            DBAuction auctionDB = new DBAuction();

            //Set the dates.
            foreach(ImageData image in images)
            {
                image.DateAdded = DateTime.Now;
            }

            auctionDB.InsertPictures(images);
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
    }
}
