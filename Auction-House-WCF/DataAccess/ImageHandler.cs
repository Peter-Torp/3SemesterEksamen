using Auction_House_WCF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.DataAccess
{
    public class ImageHandler
    {
        private readonly string _appDirectory = Path.Combine(Environment.CurrentDirectory, @"..\..\"); // AppDomain.CurrentDomain.BaseDirectory
        private readonly string _baseDirectory = @"Images\Auctions";

        public bool InsertPictureToFolder(ImageData image)
        {
            bool successful = false;

            string userDirectory = Path.Combine(_appDirectory, _baseDirectory, image.UserId.ToString());
            string auctionDirectory = Path.Combine(userDirectory, image.AuctionId.ToString());
            string fullPath = Path.Combine(auctionDirectory, image.FileName);

            //Check if user id is in folders
            if (!Directory.Exists(userDirectory))
            {
                Directory.CreateDirectory(userDirectory);
            } 
            //Check if auction id is in folders
            if (!Directory.Exists(auctionDirectory))
            {
                Directory.CreateDirectory(auctionDirectory);
            }

            //Check if file name exists in end folder.
            if (!File.Exists(fullPath))
            {
                var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                
                image.FileStream.CopyTo(fileStream);

                fileStream.Dispose();

                successful = true;
            } else
            {
                successful = true;
            }
            return successful;
        }

        public bool InsertPicturesToFolder(List<ImageData> images)
        {
            bool successful = false;

            foreach (ImageData image in images)
            {
                successful = InsertPictureToFolder(image);
                if (!successful)
                {
                    return successful;
                }
            }
            return successful;
        }

        public RemoteFileInfo GetPicture(DownloadRequest request)
        {
            RemoteFileInfo rFI = new RemoteFileInfo();
            try
            {
                string userDirectory = Path.Combine(_appDirectory, _baseDirectory, request.UserId.ToString());
                string auctionDirectory = Path.Combine(userDirectory, request.AuctionNumber.ToString());
                string fullDirectory = Path.Combine(auctionDirectory, request.FileName);

                bool fileExist = File.Exists(fullDirectory);
                if (fileExist)
                {
                    FileStream imgFile = File.OpenRead(fullDirectory);
                    rFI.FileByteStream = imgFile;
                    return rFI;
                }
                else
                {
                    FileStream imgFile = File.OpenRead(Path.Combine(_appDirectory, _baseDirectory, "projekt-notfound.jpg"));
                    rFI.FileByteStream = imgFile;
                    return rFI;
                    //throw new FileNotFoundException("File not found at: " + fullDirectory, request.FileName);
                }
            }
            catch (IOException exp)
            {
                throw exp;
            }
        }
    }


}
