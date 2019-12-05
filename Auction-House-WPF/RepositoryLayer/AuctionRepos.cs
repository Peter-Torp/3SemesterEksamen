using Auction_House_WPF.ServiceLayer;
using ModelLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interface;

namespace RepositoryLayer
{
    public class AuctionRepos : IAuction
    {
        IAuctionServiceLayer auction;

        public AuctionRepos()
        {
            auction = new AuctionService();
        }

        public bool deleteAuctionById(int id)
        {
            throw new NotImplementedException();
        }

        public List<AuctionModel> getAuctionsByUserName(string userName)
        {
            return auction.getAuctionsByUserName(userName);
        }
    }
}
