using Auction_House_WCF.Controllers;
using Auction_House_WCF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Services
{
    class AuctionService : IAuctionService
    {
        public AuctionData GetActiveAuctionsByUsername(string userName)
        {
            throw new NotImplementedException();
        }


        public AuctionData GetDoneAuctionsByUsername(string userName)
        {
            throw new NotImplementedException();
        }

        public RemoteFileInfo GetPicture(DownloadRequest request)
        {
            /*
                        RemoteFileInfo result = new RemoteFileInfo();
                        try
                        {
                            string filePath = System.IO.Path.Combine(@"", request.FileName);
                            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);

                            // check if exists
                            if (!fileInfo.Exists)
                                throw new System.IO.FileNotFoundException("File not found",
                                                                          request.FileName);

                            // open stream
                            System.IO.FileStream stream = new System.IO.FileStream(filePath,
                                      System.IO.FileMode.Open, System.IO.FileAccess.Read);

                            // return result 
                            result.FileName = request.FileName;
                            result.Length = fileInfo.Length;
                            result.FileByteStream = stream;
                            return result;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
            */
            AuctionController aCtr = new AuctionController();
            return aCtr.GetPicture(request);
        }

        public int InsertAuction(AuctionData aData)
        {
            AuctionController aCtr = new AuctionController();

            return aCtr.InsertAuction(aData);
        }

        public void InsertPicture(RemoteFileInfo request)
        {
            throw new NotImplementedException();
        }


        public List<AuctionData> GetAuctions(string auctionName)
        {
            AuctionController aCtr = new AuctionController();
            return aCtr.GetAuctions(auctionName);
        }


    }
}
