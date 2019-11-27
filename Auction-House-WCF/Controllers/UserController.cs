﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WCF.DataAccess;
using Auction_House_WCF.Models;

namespace Auction_House_WCF.Controllers
{
    public class UserController
    {
        public int InsertUser(string userName, string email, string phone, string zipCode, string region, string password)
        {
            DBUser userDB = new DBUser();

            UserData userData = new UserData
            {
                UserName = userName,
                Email = email,
                Phone = phone,
                ZipCode = zipCode,
                Region = region,
                
            };

            LoginController.HashWithIterate(password, userData);    //return userData with changed properties (salt and passwordHash).

            return userDB.Create(userData);
        }

        public UserData GetUser(int id)
        {
            DBUser userDB = new DBUser();
            return userDB.Get(id);
        }

        public UserData GetUserByUserName(string userName)
        {
            DBUser userDB = new DBUser();
            return userDB.GetByUserName(userName);
        }
    }
}
