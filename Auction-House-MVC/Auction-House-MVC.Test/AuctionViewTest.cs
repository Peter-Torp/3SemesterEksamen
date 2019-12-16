using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Auction_House_MVC.Controllers;
using Auction_House_MVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Auction_House_MVC.Test
{
    [TestClass]
    public class AuctionViewTest
    {
        // https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/unit-testing/creating-unit-tests-for-asp-net-mvc-applications-cs
        [TestMethod]
        public void TestShowBidsView()
        {
            //Arrange
            var aCtr = new AuctionController();
            List<BidViewModel> showBids = new List<BidViewModel>();

            BidViewModel bid = new BidViewModel
            {
                Amount = 200,
                Date = DateTime.Now,
                UserName = "Bøv"
            };

            showBids.Add(bid);

            //Act
            var result = aCtr.ShowBids(showBids) as ViewResult;

            //Assert
            Assert.AreEqual("ShowBids", result.ViewName);
        }
    }
}
