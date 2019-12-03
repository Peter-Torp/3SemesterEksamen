using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WPF.ModelLayer;
using Auction_House_WPF.ServiceLayer.Utility;
using Auction_House_WPF.ServiceAccessExceptions;
using ServiceLayer.UserServiceReference;
using IUserService = ServiceLayer.UserServiceReference.IUserService;

namespace Auction_House_WPF.ServiceLayer
{
    public class UserService
    {

        /*
         * Call a service to get a user by userName. It returns UserData type.
         * This method calls the utility class UserUtility to convert the data to a PersonModel object
         * and returns the PersonModel object
         * After use it disposes the UserUtility object
         */
        public UserModel GetUserByUserName(string UserName)
        {
            UserModel userModel = null;

            UserData user = null;
            try
            {
                IUserService _userClientUserName = createServiceClient();
                user = _userClientUserName.GetUserByUserName(UserName);

                userModel = UserUtility.ConvertUserDataToUserModelData(user);

            }
            catch (ServiceAccessException)
            {
                throw new ServiceAccessException(ExceptionMessages.Couldnt_Retrive_User_From_Service);
            }
            

            return userModel;
        }

        /*
         * Call a service to get a user by userId. It returns UserData type.
         * This method calls the utility class UserUtility to convert the data to a PersonModel object
         * and returns the PersonModel object
         * After use it disposes the UserUtility object
         */
        public UserModel getUserId(int userId)
        {
            UserModel userModel = null;
            UserData user;

            try
            {
                IUserService _userServiceId = createServiceClient();
                user = _userServiceId.GetUserById(userId);

                userModel = UserUtility.ConvertUserDataToUserModelData(user);
            }
            catch (ServiceAccessException)
            {
                throw new ServiceAccessException(ExceptionMessages.Couldnt_Retrive_User_From_Service);
            }
            

            return userModel;
        }

        /*
         * Create service client and use its interface.
         * Method is to be used generally and is better troubleshooted.
         * Returns a _userService object
         */
        private IUserService createServiceClient()
        {
            IUserService _userService = null;
            try
            {
                _userService = new UserServiceClient();
            }
            catch (ServiceAccessException)
            {
                throw new ServiceAccessException(ExceptionMessages.Couldnt_Instantiate_Service_Client);
            }
            return _userService;
        }







    }
}