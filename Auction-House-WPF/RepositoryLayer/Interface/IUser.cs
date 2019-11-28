
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WPF.ModelLayer;

namespace Auction_House_WPF.RepositoryLayer.Interface
{
    internal interface IUserRepos
    {
        UserModel GetUserByUserName(string _userName);

        UserModel GetUserById(int id);



    }

}