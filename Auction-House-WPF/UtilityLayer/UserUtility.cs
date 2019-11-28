using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WPFAuctionHouse.Utility
{
    class UserUtility
    {

        public UserModel ConvertUserDataToUserModelData(UserData _userData)
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


    }
}