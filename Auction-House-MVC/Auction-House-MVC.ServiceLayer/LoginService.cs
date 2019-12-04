using Auction_House_MVC.ServiceLayer.LoginServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.ServiceLayer
{
    public class LoginService
    {

        public bool Login(string password, string userName)
        {
            ILoginService lClient = new LoginServiceClient();

            return lClient.Verify(password, userName);

            
        }

    }
}