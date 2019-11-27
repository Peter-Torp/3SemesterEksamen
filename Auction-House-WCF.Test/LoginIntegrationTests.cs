using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WCF.Controllers;
using Auction_House_WCF.DataAccess;
using Auction_House_WCF.Models;
using Auction_House_WCF.Services;

namespace Auction_House_WCF.Test
{
    [TestClass]
    public class LoginIntegrationTests
    {
        private LoginService loginService;
        private DBLogin dbLogin;
        private UserController userController;
        private UserService userService;

        [TestInitialize]
        public void BeforeEachTestInitialize()
        {
            loginService = new LoginService();
            dbLogin = new DBLogin();
            userService = new UserService();
            userController = new UserController();
        }

        [TestMethod]
        public void TestWithValidUserName()
        {
            //Arrange
            string testUserName1 = "Peter";
            string testPassword1 = "placeholder";
            //Act
            //userController.InsertUser("Peter", "hansJørgen@gmail.com", "82838484", "2342", "Nordjylland", "placeholder");
            bool loginAttempt = loginService.Verify(testPassword1 ,testUserName1);
            //Assert
            Assert.IsTrue(loginAttempt);
        }

        [TestMethod]
        public void TestWithInvalidUserName()
        {
            //Arrange
            string userName2 = "AWDS";
            string password2 = "placeholder";
            //Act
            bool loginAttempt2 = loginService.Verify(password2, userName2);
            //Assert
            Assert.IsFalse(loginAttempt2);
        }



        [TestMethod]
        public void TestWithInvalidPassword()
        {
            //Arrange
            string userName4 = "Magnus";
            string password4 = "zxcv";
            //Act
            bool loginAttempt4 = loginService.Verify(password4, userName4);
            //Assert
            Assert.IsFalse(loginAttempt4);
        }

        /*[TestMethod]
        public void TestUserNameIntegerValuesInUserName()
        {
            //Arrange
            int userName5 = 12345;
            string password5 = "placeholder";
            //Act
            bool loginAttempt5 = loginService.Verify(password5, userName5);
            //Assert
            Assert.IsFalse(loginAttempt5);
        }*/

        /*[TestMethod]
        public void TestPasswordWithIntegerValuesInPassword()
        {
            //Arrange
            string userName6 = "Magnus";
            int password6 = 12345;
            //Act
            bool loginAttempt6 = loginService.Verify(password6, userName6);
            //Assert
            Assert.IsFalse(loginAttempt6);
        }*/

        [TestMethod]
        public void TestWithEmptyPassword()
        {
            //Arrange
            string userName7 = "Magnus";
            string password7 = "";
            //Act
            bool loginAttempt7 = loginService.Verify(password7, userName7);
            //Assert
            Assert.IsFalse(loginAttempt7);
        }

        [TestMethod]
        public void TestWithEmptyUserName()
        {
            //Arrange
            string userName8 = "Magnus";
            string password8 = "";
            //Act
            bool loginAttempt7 = loginService.Verify(password8, userName8);
            //Assert
            Assert.IsFalse(loginAttempt7);
        }

        [TestCleanup]
        public void CleanUp()
        {
            loginService = null;
            dbLogin = null;
            //loginController = null;
            //login = null;
        }
    }
}
