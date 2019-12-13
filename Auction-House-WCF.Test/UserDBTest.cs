using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auction_House_WCF.Models;
using Auction_House_WCF.Controllers;
using System.Collections.Generic;

namespace Auction_House_WCF.Test
{
    [TestClass]
    public class UserDBTest
    {
        private int _testUserId;
        private string _testUserName;

        [TestInitialize]
        public void Initialize()
        {
            _testUserId = 468;
            _testUserName = "TEST";
        }

        [TestMethod]
        public void TestConnectionToDB()
        {
            //Arrange
            UserController uCtr = new UserController();

            //Act
            Boolean connection = uCtr.TestConnectionToDB(_testUserId);

            //Assert
            Assert.IsTrue(connection);
        }


        /////<summary>Because problems with getting the con string.</summary>
        //[TestMethod]
        //public void TestAccessToAppConfig()
        //{
        //    //Arrange
        //    DBUser DBUser = new DBUser();

        //    //Act
        //    string conString = DBUser._connectionString;

        //    //Assert
        //    Assert.IsNotNull(conString);
        //}

        [TestMethod]
        public void GetUserByUserNameTest()
        {
            //Arrange
            UserController uCtr = new UserController();
            string expectedResult = _testUserName;

            //Act
            UserData userData = uCtr.GetUserByUserName(_testUserName);

            //Assert
            Assert.AreEqual(expectedResult, userData.UserName);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            //Arrange
            UserController uCtr = new UserController();
            string expectedResult = _testUserName;

            //Act
            UserData userData = uCtr.GetUser(_testUserId);

            //Assert
            Assert.AreEqual(expectedResult, userData.UserName);
        }

        [TestMethod]
        public void CheckUserTest()
        {
            //Arrange
            UserController uCtr = new UserController();

            //Act
            bool exist = uCtr.CheckUserName(_testUserName);

            //Assert
            Assert.IsTrue(exist);
        }

        //[TestMethod]
        //public void TestInsertUser()
        //{
        //    //Arrange
        //    DBUser DBUser = new DBUser();
        //    UserData userData = new UserData
        //    {
        //        UserName = "Jørgen",
        //        Email = "Jørgen.Hus@email.dk",
        //        Phone = "34343245",
        //        ZipCode = "9000",
        //        Region = "Aalborg",
        //        PasswordHash = "dsori39i003wkifd223sf3ew",
        //        Salt = "osdapi39r34243rrei0w"
        //    };
        //    Boolean boolean = false;

        //    //Act
        //    int id = DBUser.Create(userData);

        //    if(id != -1)
        //    {
        //        boolean = true;
        //    }

        //    //Assert
        //    Assert.IsTrue(boolean);
        //}

    }
}
