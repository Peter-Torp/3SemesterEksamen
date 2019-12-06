using Auction_House_WCF.DataAccess;
using Auction_House_WCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Controllers
{
    public class BidController
    {
        public List<BidData> GetBids(int id)
        {
            DBBidding dBBidding = new DBBidding();
            return dBBidding.GetBids(id);
        }

        public bool InsertBid(BidData bidData)
        {
            DBBidding dBBidding = new DBBidding();

            // Add serverside date
            bidData.Date = DateTime.Now;

            int value = dBBidding.Create(bidData);
            bool successful = false;
            if(value == 1)
            {
                successful = true;
            }
            return successful;
        }

        public double GetMaxBidOnAuction(int auctionId)
        {
            DBBidding dBBidding = new DBBidding();
            return dBBidding.GetMaxBidOnAuction(auctionId);
        }


    }
}
