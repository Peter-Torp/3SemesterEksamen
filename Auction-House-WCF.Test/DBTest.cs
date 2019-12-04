using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auction_House_WCF.DataAccess;
using Auction_House_WCF.Models;
using Auction_House_WCF.Controllers;
using System.Collections.Generic;

namespace Auction_House_WCF.Test
{
    [TestClass]
    public class DBTest
    {
        [TestMethod]
        public void TestConnectionToDB()
        {
            //Arrange
            DBUser DBUser = new DBUser();

            //Act
            Boolean connection = DBUser.testConnection(400);

            //Assert
            Assert.IsTrue(connection);
        }


        ///<summary>Because problems with getting the con string.</summary>
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
        public void TestGetUser()
        {
            //Arrange
            DBUser DBUser = new DBUser();
            string expectedResult = "Jørgen";

            //Act
            UserData userData = DBUser.Get(400);

            //Assert
            Assert.AreEqual(expectedResult, userData.UserName);
        }

        [TestMethod]
        public void TestInsertUser()
        {
            //Arrange
            DBUser DBUser = new DBUser();
            UserData userData = new UserData
            {
                UserName = "Jørgen",
                Email = "Jørgen.Hus@email.dk",
                Phone = "34343245",
                ZipCode = "9000",
                Region = "Aalborg",
                PasswordHash = "dsori39i003wkifd223sf3ew",
                Salt = "osdapi39r34243rrei0w"
            };
            Boolean boolean = false;

            //Act
            int id = DBUser.Create(userData);

            if(id != -1)
            {
                boolean = true;
            }

            //Assert
            Assert.IsTrue(boolean);
        }

        [TestMethod]
        public void TestInsertAuction()
        {
            //Arrange
            AuctionController aCtr = new AuctionController();
            AuctionData auctionData = new AuctionData
            {
                StartPrice = 300,
                BuyOutPrice = 600,
                BidInterval = 20,
                Description = "Nice IPhone from 2012",
                EndDate = new DateTime(2020,2,5),
                Category = "Name",
                UserName = "Magnus"
            };
            Boolean boolean = false;

            //Act
            int id = aCtr.InsertAuction(auctionData);

            if(id != -1)
            {
                boolean = true;
            }

            //Assert
            Assert.IsTrue(boolean);

        }

        [TestMethod]
        public void TestGetUserAuctions()
        {
            //Arrange
            AuctionController aCtr = new AuctionController();
            bool NotEmpty;

            //Act
            List<AuctionData> auctions = aCtr.GetUserAuctions("Magnus");
            int count = auctions.Count;
            if(count > 0)
            {
                NotEmpty = true;
            }
            else
            {
                NotEmpty = false;
            }

            //Assert
            Assert.IsTrue(NotEmpty);
        }

        [TestMethod]
        public void TestGetBids()
        {
            //Arrange 
            BidController bCtr = new BidController();
            bool NotEmpty;

            //Act
            List<BidData> bidData = bCtr.GetBids();
            if (bidData.Count > 0)
            {
                NotEmpty = true;
            }
            else
            {
                NotEmpty = false;
            }

            //Assert
            Assert.IsTrue(NotEmpty);

        }
    }
}
