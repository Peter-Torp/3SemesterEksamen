using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WPF.ModelLayer;

namespace Auction_House_WPF.ServiceLayer.Interface
{
    interface IUserService
    {
        UserModel GetUserByUserName(string userName);
        UserModel GetUserById(int id);

    }
}
