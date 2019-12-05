using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WCF.Models;
using Auction_House_WCF.Controllers;

namespace Auction_House_WCF.Services
{
    public class UserService : IUserService
    {
        public UserData GetUserById(int id)
        {
            UserController uCtr = new UserController();
            return uCtr.GetUser(id);
        }

        public int InsertUser(string userName, string email, string phone, string zipCode, string region, string password)
        {
            UserController uCtr = new UserController();
            return uCtr.InsertUser(userName,email,phone,zipCode,region,password);
        }

        public string TestString()
        {
            return "This is a test";
        }

        public UserData GetUserByUserName(string userName)
        {
            UserController uCtr = new UserController();
            return uCtr.GetUserByUserName(userName);
        }

        public bool CheckUserName(string userName)
        {
            UserController uCtr = new UserController();
            return uCtr.CheckUserName(userName);
        }
    }
}
