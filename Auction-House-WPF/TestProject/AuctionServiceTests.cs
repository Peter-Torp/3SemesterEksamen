using Auction_House_WPF.ServiceLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class AuctionServiceTests
    {
        AuctionService auctionService = null;

        [TestInitialize]
        public void SetUpBeforeEach()
        {
            auctionService = new AuctionService();
        }

        [TestMethod]
        public void GetAllAuctions()        //Service method is not done
        {
            //Arrange
            List<AuctionModel> auctions;
            //Act
            auctions = auctionService.GetAllAuctions();
            //Assert
            Assert.IsNotNull(auctions.Count);
            
        }

        [TestMethod]
        public void GetAuctionsByUserName()
        {
            //Arrange
            string testUserName = "Jørgen";
            List<AuctionModel> auctions;
            //Act
            auctions = auctionService.GetAuctionsByUserName(testUserName);
            //Assert
            Assert.IsNotNull(auctions.Count);
        }

        [TestMethod]
        public void TryGetAuctionsByInvalidUserName()
        {
            //Arrange
            string testUserName = "AWDSAWDS";
            List<AuctionModel> auctions;
            //Act
            auctions = auctionService.GetAuctionsByUserName(testUserName);
            //Assert
            Assert.AreEqual(0,auctions.Count);      //try catch
        }


        [TestCleanup]
        public void CleanUp()
        {
            auctionService = null;
        }

    }
}
