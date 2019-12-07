using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WCF.Controllers;
using Auction_House_WCF.Models;

namespace Auction_House_WCF.Services 
{
    public class LoginService : ILoginService
    {
        //Take a string and sent it to the controller. Including a userName to connect it with.
        public bool Verify(string password, string userName)
        {
            return LoginController.Verify(password, userName);
        }

        //create login
        public UserData CreateLogin(string password, UserData userData)
        {
            return LoginController.HashWithIterate(password, userData);
        }
    }
}
