using Auction_House_MVC.BusinessLayer;
using Auction_House_MVC.ModelLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_MVC.Test
{
    [TestClass]
    public class IntegrationUserTest
    {
        private string _testUserName;

        [TestInitialize]
        public void Initialize()
        {
            //Test user on DB.
            _testUserName = "TEST";
        }

        [TestMethod]
        public void GetUserByUserNameTest()
        {
            //Arrange
            B_UserController uCtr = new B_UserController();
            string expectedResult = _testUserName;

            //Act
            User user = uCtr.GetUserByUserName(_testUserName);

            //Assert
            Assert.AreEqual(expectedResult, user.UserName);
        }

        [TestMethod]
        public void CheckUserTest()
        {
            //Arrange
            B_UserController uCtr = new B_UserController();

            //Act
            bool exist = uCtr.CheckUserName(_testUserName);

            //Assert
            Assert.IsTrue(exist);
        }

    }
}
