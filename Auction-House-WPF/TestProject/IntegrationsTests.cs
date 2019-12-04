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
            //Act
            secondChildViewModel.SearchUserByUserName(testInput);
            //Assert
            Assert.AreEqual(1, secondChildViewModel.UserShowModel.Count);
        }

        [TestMethod]
        public void TryGetUserByUserNameInvalid()
        {
            //Arrange
            string testInput = "AWDSAWDS";
            //Act
            secondChildViewModel.SearchUserByUserName(testInput);
            //Assert
            Assert.AreEqual(0, secondChildViewModel.UserShowModel.Count);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            secondChildViewModel = null;
            
        }


    }
}
