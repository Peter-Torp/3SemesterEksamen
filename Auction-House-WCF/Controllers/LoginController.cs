using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WCF.DataAccess;
using Auction_House_WCF.Models;

namespace Auction_House_WCF.Controllers
{
    public static class LoginController
    {

        private const int SaltSize = 16;
        //private const int HashSize = 20;

        /*
         * Create hashed password with a string
        */
        internal static UserData HashAndSaltPassword(string password, UserData userData)
        {
            

            if (password != null && userData != null)
            {
                //create salt with the length of SaltSize
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

                //create hash and combine hash and salt
                byte[] passBytes = Encoding.UTF8.GetBytes(password);
                SHA256Managed sHA256ManagedString = new SHA256Managed();
                byte[] saltHash = sHA256ManagedString.ComputeHash(salt);
                byte[] passHash = sHA256ManagedString.ComputeHash(passBytes);

                //convert to base64String
                userData.PasswordHash = Convert.ToBase64String(passHash) + Convert.ToBase64String(saltHash);
                userData.Salt = Convert.ToBase64String(saltHash);
                
            }
            else
            {
                Console.WriteLine("Couldnt create password. Try again!");
            }

            return userData;
        }

        //Iterate the hashed password 10000 times = Max confusion
        //Start method - Not in use yet!
        internal static UserData HashWithIterate(string password, UserData userData)
        {
            return HashAndSaltPassword(password, userData);
        }

        //Verify password
        internal static bool Verify(string password, string userName)
        {

            DBUser dBUser = new DBUser();
            UserController userController = new UserController();

            UserData inputUser = userController.GetUserByUserName(userName);
            string encryptedPass = Encrypt(password);
            string hashedAndSaltedPass = encryptedPass + inputUser.Salt;


            //check salt and then hash
            if (inputUser.PasswordHash == hashedAndSaltedPass) 
            {
                Console.WriteLine("Login succeded!");    
            } 
            else
            {
                Console.WriteLine("Login failed!");
                return false;
            }
            return true;


        }

        //Used for verify method
        internal static string Encrypt(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);



            string hash1 = Convert.ToBase64String(hash);

            return hash1;
        }



    }
}

