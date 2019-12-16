using Auction_House_MVC.ModelLayer;
using Auction_House_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_MVC.Utility
{
    interface IViewModel
    {
        UserSignUp ConvertFromUserSignUpModelToSignUp(UserSignUpModel uSUModel);
        UserViewModel ConvertFromUserToUserShowModel(User user);
        CreateAuction ConvertFromAuctionSetUpToCreateAuction(AuctionSetUpModel aSU, string userName);
    }
}
