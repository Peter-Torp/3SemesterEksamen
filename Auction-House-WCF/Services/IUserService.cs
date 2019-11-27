using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WCF.Models;

namespace Auction_House_WCF.Services
{
    [ServiceContract]
    interface IUserService
    {
        [OperationContract]
        UserData GetUserById(int id);
        [OperationContract]
        UserData GetUserByUserName(string userName);
        [OperationContract]
        int InsertUser(string userName, string email, string phone, string zipCode, string region, string password);
        [OperationContract]
        string TestString();
    }
}