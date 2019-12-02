using Auction_House_WPF.Model;
using Auction_House_WPF.ModelLayer;
using Auction_House_WPF.Repository;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WPF.ViewModels
{
    public class SecondChildViewModel : Screen
    {
        public UserShowModel foundUser;
        public string FirstName, LastName, UserName, Address, Email, Phone, ZipCode, DateOfBirth;
        internal string inputString;


        //Metode til at finde en model.
        public void getUserByUserName(string userName)
        {
            UserRepos userRepos = new UserRepos();
            foundUser = ConvertUserModelToUserShowModel(userRepos.GetUserByUserName(userName));

            this.FirstName = foundUser.FirstName;
            this.LastName = foundUser.LastName;
            this.UserName = foundUser.UserName;
            this.Address = foundUser.Address;
            this.Email = foundUser.Email;
            this.Phone = foundUser.Phone;
            this.ZipCode = foundUser.Zipcode;
            this.DateOfBirth = foundUser.DateofBirth;
        }

        /*
         * Convert UserModel type to UserShowModel type. 
         * */
        public UserShowModel ConvertUserModelToUserShowModel(UserModel user)
        {
            UserShowModel foundUser = new UserShowModel(user);
            foundUser.FirstName = user.FirstName;
            foundUser.LastName = user.LastName;
            foundUser.UserName = user.Username;
            foundUser.Address = user.Address;
            foundUser.Email = user.Email;
            foundUser.Phone = user.Phone;
            foundUser.Zipcode = user.Zipcode;
            foundUser.DateofBirth = user.DateofBirth;

            return foundUser;
        }

       
        

    }


}