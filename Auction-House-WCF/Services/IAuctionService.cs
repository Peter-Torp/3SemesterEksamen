using Auction_House_WCF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Services
{
    [ServiceContract]
    interface IAuctionService
    {
        [OperationContract]
        AuctionData GetActiveAuctionsByUsername(string userName);
        [OperationContract]
        AuctionData GetDoneAuctionsByUsername(string userName);
        [OperationContract]
        int InsertAuction(AuctionData aData);

        [OperationContract]
        void InsertPicture(ImageData image);
        [OperationContract]
        RemoteFileInfo GetPicture(DownloadRequest request);

        [OperationContract]
        bool InsertPictures(List<ImageData> images);

        [OperationContract]
        List<AuctionData> GetAuctions(string auctionName);
        [OperationContract]
        List<AuctionData> GetUserAuctions(string userName);
        [OperationContract]
        AuctionData GetAuction(int auctionId);
        [OperationContract]
        List<string> GetCategories();
        [OperationContract]
        List<ImageInfoData> GetImages(int auctionId);
        [OperationContract]
        List<AuctionData> GetLatestAuctions();
        [OperationContract]
        List<BidData> GetBids(int id);
        [OperationContract]
        bool InsertBid(BidData bidData);
        [OperationContract]
        double GetMaxBidOnAuction(int auctionId);
        [OperationContract]
        bool DeleteAuctionById(int id);

    }
}
