using Auction_House_MVC.ModelLayer;
using Auction_House_MVC.ServiceLayer.AuctionServiceReference;
using Auction_House_MVC.ServiceLayer.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_MVC.ServiceLayer.Utility
{
    interface IDataModel
    {
        AuctionData ConvertFromCreateAuctionToAuctionData(CreateAuction createAuction);
        UserLogin ConvertFromUserDataToLogin(UserData userData);
        User ConvertFromUserDataToUser(UserData userData);

    }
}
