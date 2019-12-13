using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WPF.ModelLayer;
using Auction_House_WPF.ServiceLayer.Utility;
using ServiceLayer.LoginServiceReference;

namespace ServiceLayer.UserServiceReference
{
    public class LoginService
    {

        //Create login
        public UserData CreateLogin(string pass, UserModel userModel)
        {
            using (LoginServiceClient proxy = new LoginServiceClient())
            {
                return proxy.CreateLogin(pass, UserUtility.ConvertUserModelToUserData(userModel));//returns userData with pass and salt
            }
        }
        


    }
}
