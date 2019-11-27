using Auction_House_MVC.ModelLayer;
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

        public RemoteFileInfo GetPicture(DownloadRequest downloadRequest)
        {
            // Use streaming endpoint. Because images = larger files.
            IAuctionService aSClient = new AuctionServiceClient("BasicHttpBinding_IAuctionService_Streaming");

            return aSClient.GetPicture(downloadRequest);

        }
    }
}