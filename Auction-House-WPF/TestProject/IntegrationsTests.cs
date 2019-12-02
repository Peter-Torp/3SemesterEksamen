using Auction_House_WPF.Model;
using Auction_House_WPF.ModelLayer;
using Auction_House_WPF.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class IntegrationsTests
    {
        SecondChildViewModel secondChildViewModel;

        [TestInitialize]
        public void ArrangeBeforeEachTest()
        {
            secondChildViewModel = new SecondChildViewModel();
        }

        [TestMethod]
        public void GetUserByUserName()
        {
            //Arrange
            string testInput = "Magnus";
            UserModel testOutput = new UserModel(null, null, "Magnus", null, null, null, null, null);
            //Act
            UserShowModel foundUser = secondChildViewModel.getUserByUserName(testInput);
            UserShowModel testUser = new UserShowModel(testOutput);
            //Assert
            Assert.AreEqual(foundUser.UserName, testUser.UserName); 
        }

        [TestMethod]
        public void TryGetUserByUserNameInvalid()
        {
            //Arrange
            string testInput = "AWDSAWDS";
            //Act
            UserShowModel foundUser = secondChildViewModel.getUserByUserName(testInput);
            //Assert
            Assert.IsNull(foundUser);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            secondChildViewModel = null;
            
        }


    }
}
