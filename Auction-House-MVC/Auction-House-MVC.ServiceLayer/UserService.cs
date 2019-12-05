using Auction_House_MVC.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction_House_MVC.ServiceLayer.UserServiceReference;
using Auction_House_MVC.ServiceLayer.Utility;

namespace Auction_House_MVC.ServiceLayer
{
    public class UserService
    {
        /// <summary>
        /// Gets user from service.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUserByUserName(string userName)
        {
            IUserService uSClient = new UserServiceClient("BasicHttpBinding_IUserService");

            ConvertDataModel converter = new ConvertDataModel();

            return converter.ConvertFromUserDataToUser(uSClient.GetUserByUserName(userName));
        }

        public UserLogin GetLoginByUsername(string userName)
        {
            IUserService uSClient = new UserServiceClient("BasicHttpBinding_IUserService");

            ConvertDataModel converter = new ConvertDataModel();

            return converter.ConvertFromUserDataToLogin(uSClient.GetUserByUserName(userName));
        }

        public bool InsertUser(UserSignUp uSU)
        {
            IUserService uSClient = new UserServiceClient("BasicHttpBinding_IUserService");

            bool confirmed = false;

            int id = uSClient.InsertUser(
            uSU.UserName,
            uSU.Email,
            uSU.Phone,
            uSU.ZipCode,
            uSU.Region,
            uSU.Password);

            if(id != -1)
            {
                confirmed = true;
            }

            return confirmed;
        }

        public bool CheckUserName(string userName)
        {
            IUserService uSClient = new UserServiceClient("BasicHttpBinding_IUserService");
            return uSClient.CheckUserName(userName);
        }
    }
}