using Auction_House_WCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Services
{
    [ServiceContract]
    interface ILoginService
    {
        [OperationContract]
        UserData CreateLogin(string password, UserData userData);

        [OperationContract]
        bool Verify(string password, string userName);


    }
}
