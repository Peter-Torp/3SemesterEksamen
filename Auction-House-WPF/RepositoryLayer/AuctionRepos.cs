using ModelLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class AuctionRepos : IAuction
    {
        IAuction auction;
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
