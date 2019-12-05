using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WPF.ServiceLayer;
using Auction_House_WPF.ModelLayer;

namespace TestProject
{
    [TestClass]
    public class ServiceTests
    {
        UserService userService; 
        
        [TestInitialize]
        public void SetupBeforeEachTest()
        {
            userService = new UserService();
        }

        [TestMethod]
        public void TestGetAUserByUserName()
        {
            //Arrange
            string input = "Magnus";
            UserModel testUser = new UserModel(null,null,"Magnus",null,null,null,null,null);
            //Act
            UserModel output = userService.GetUserByUserName(input);
            //Assert
            Assert.AreEqual(testUser.Username, output.Username);
        }

        [TestMethod] 
        public void TestGetUserBuInvalidUserName()
        {
            //Arrange
            string input = "AWDSAWDS";
            //Act
            UserModel output = userService.GetUserByUserName(input);
            //Assert
            Assert.IsNull(output);
        }

        [TestCleanup]
        public void Cleanup()
        {
            userService = null;
        }
        



    }
}
