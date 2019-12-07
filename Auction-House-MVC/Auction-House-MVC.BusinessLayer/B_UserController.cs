using Auction_House_MVC.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction_House_MVC.ServiceLayer.UserServiceReference;
using Auction_House_MVC.ServiceLayer;

namespace Auction_House_MVC.BusinessLayer
{
    public class B_UserController
    {
        public User GetUserByUserName(string userName)
        {
            UserService uS = new UserService();

            return uS.GetUserByUserName(userName);
        }

        public bool Login(string userName, string password)
        {
            LoginService lS = new LoginService();

            return lS.Login(password, userName);
        }

        public bool SignUp(UserSignUp uSU)
        {
            UserService uS = new UserService();


            return uS.InsertUser(uSU);
        }

        public bool CheckUserName(string userName)
        {
            UserService uS = new UserService();
            return uS.CheckUserName(userName);
        }
    }
}