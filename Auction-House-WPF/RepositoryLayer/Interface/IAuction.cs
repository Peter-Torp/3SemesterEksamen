using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace RepositoryLayer.Interface
{
    interface IAuction
    {
        List<AuctionModel> getAuctionsByUserName(string userName);
        void deleteAuctionById(int id);


    }
}
