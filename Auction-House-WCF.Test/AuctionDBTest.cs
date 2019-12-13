using Auction_House_WCF.Controllers;
using Auction_House_WCF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Test
{
    class AuctionDBTest
    {

        [TestMethod]
        public void GetUserAuctionsTest()
        {
            //Arrange
            AuctionController aCtr = new AuctionController();
            bool NotEmpty;

            //Act
            List<AuctionData> auctions = aCtr.GetUserAuctions("Jørgen");
            int count = auctions.Count;
            if (count > 0)
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

        //[TestMethod]
        //public void TestInsertAuction()
        //{
        //    //Arrange
        //    AuctionController aCtr = new AuctionController();
        //    AuctionData auctionData = new AuctionData
        //    {
        //        StartPrice = 300,
        //        BuyOutPrice = 600,
        //        BidInterval = 20,
        //        Description = "Nice IPhone from 2012",
        //        EndDate = new DateTime(2020,2,5),
        //        Category = "Name",
        //        UserName = "Magnus"
        //    };
        //    Boolean boolean = false;

        //    //Act
        //    int id = aCtr.InsertAuction(auctionData);

        //    if(id != -1)
        //    {
        //        boolean = true;
        //    }

        //    //Assert
        //    Assert.IsTrue(boolean);

        //}

    }
}
