using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WPF.ModelLayer;
using Auction_House_WPF.RepositoryLayer.Interface;
using Auction_House_WPF.ServiceLayer;


namespace Auction_House_WPF.Repository
{
    public class UserRepos : IUserRepos
    {

        //UserService uSP = new UserService();

        public UserModel GetUserById(int id)
        {
            UserModel person = null;

            return null;
        }

        /*
         * Get user by userName. Calls the UserServiceProxy method GetUser
         * which takes a string userName as parameter
         * and returning a PersonModel object
         */
        public UserModel GetUserByUserName(string _userName)
        {
            UserService uSP = new UserService();
            UserModel user = null;
            try {

                user = uSP.GetUserByUserName(_userName);
            } 
            catch (NullReferenceException e)
            {
                throw e;
            }
            
            return user;
        }

        

    }
}