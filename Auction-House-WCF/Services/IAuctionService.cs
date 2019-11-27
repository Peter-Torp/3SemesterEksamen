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
        void InsertPicture(RemoteFileInfo request);
        [OperationContract]
        RemoteFileInfo GetPicture(DownloadRequest request);
    }
}
