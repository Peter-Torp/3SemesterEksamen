using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WPF.ModelLayer;
using ServiceLayer.UserServiceReference;

namespace Auction_House_WPF.ServiceLayer.Utility
{
    static class UserUtility
    {

        public static UserModel ConvertUserDataToUserModelData(UserData _userData)
        {
            UserModel userModel = new UserModel(null, null, null, null, null, null, null, null)
            {
                FirstName = null,
                LastName = null,
                Username = _userData.UserName,
                Address = _userData.Region,
                Email = _userData.Email,
                Phone = _userData.Phone,
                Zipcode = _userData.ZipCode,
                DateofBirth = null

            };
            return userModel;
        }

        internal static UserData ConvertUserModelToUserData(UserModel userModel)
        {
            UserData userData = new UserData
            {
                Id = userModel.User_Id,
                UserName = userModel.Username,
                Email = userModel.Email,
                Phone = userModel.Phone,
                ZipCode = userModel.Zipcode,
                Region = null,
                PasswordHash = null,
                Salt = null
            };

            return userData;
        }

        

        
            
           
    }
}
