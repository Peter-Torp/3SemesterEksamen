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
            //Act
            //Assert
        }

        [TestMethod]
        public void TryGetUserByUserNameInvalid()
        {
            //Arrange
            //Act
            //Assert
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            secondChildViewModel = null;
            
        }


    }
}
