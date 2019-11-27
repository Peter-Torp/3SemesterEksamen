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
            bool authenticated = false;

            //Get user login information from DB.
            UserService uS = new UserService();
            UserLogin userLogin = uS.GetLoginByUsername(userName);

            //Salt and hash password here.
            string saltedPassword = userLogin.Salt + password;
            string hashedPassword = password;

            //Compare stored hash with the generated hash.
            if(userLogin.Hash == hashedPassword)
            {
                authenticated = true;
            }
            return authenticated;
        }

        public bool SignUp(UserSignUp uSU)
        {
            UserService uS = new UserService();


            return uS.InsertUser(uSU);
        }
    }
}