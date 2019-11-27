using Auction_House_MVC.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_MVC.ModelLayer;

namespace Auction_House_MVC.Utility
{
    interface IDataModel
    {
        User ConvertFromUserDataToUser(UserData userData);
    }
}
