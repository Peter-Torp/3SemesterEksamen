using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IAuctionServiceLayer
    {
        List<AuctionModel> GetAuctionsByUserName(string userName);
        void DeleteAuctionById(int id);
        List<AuctionModel> GetAllAuctions();
    }
}
