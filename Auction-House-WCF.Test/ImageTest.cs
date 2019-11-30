using Auction_House_WCF.Controllers;
using Auction_House_WCF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Test
{
    class ImageTest
    {
        [TestClass]
        public class DBTest
        {
            [TestMethod]
            public void TestInsertPicture()
            {
                AuctionController aCtr = new AuctionController();
                DownloadRequest downloadRequest = new DownloadRequest();

                downloadRequest.FileName = "image_1.jpg";
                downloadRequest.UserId = 400;
                downloadRequest.AuctionNumber = 1;

                ImageData imageData = new ImageData();
                RemoteFileInfo rFI = new RemoteFileInfo();

                rFI = aCtr.GetPicture(downloadRequest);

                imageData.FileStream = rFI.FileByteStream;
                imageData.FileName = downloadRequest.FileName;
                imageData.UserId = 401;
                imageData.AuctionId = 4;

                Assert.IsTrue(aCtr.InsertPicture(imageData));
            }
        }
    }
}
