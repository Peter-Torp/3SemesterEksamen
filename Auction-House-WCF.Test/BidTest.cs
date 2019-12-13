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
    class BidTest
    {

        [TestMethod]
        public void GetBidsTest()

        {
            //Arrange 
            BidController bCtr = new BidController();
            bool NotEmpty;

            //Act
            List<BidData> bidData = bCtr.GetBids(5);
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
