using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_MVC.Utility;
using System.Web;
using Auction_House_MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace Auction_House_MVC.Test
{
    [TestClass]
    public class UtilityTest
    {

        [TestMethod]
        public void DateCheckerFailTest()
        {
            //Arrange
            CheckDateTime checkDateTime = new CheckDateTime();
            //Set dateTime to yesterday
            DateTime dateTime = DateTime.Now.AddDays(-1);
            object value = dateTime;

            //Act
            bool valid = checkDateTime.IsValid(value);

            //Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void DateCheckerSuccessTest()
        {
            //Arrange
            CheckDateTime checkDateTime = new CheckDateTime();
            //Set dateTime to 5 days ahead of today.
            DateTime dateTime = DateTime.Now.AddDays(5);
            object value = dateTime;

            //Act
            bool valid = checkDateTime.IsValid(value);

            //Assert
            Assert.IsTrue(valid);
        }


        //[TestMethod]
        //public void FileCheckerTest()
        //{
        //    //Arrange
        //    CheckImageFile checkImageFile = new CheckImageFile();

        //    //Act
        //    bool valid = checkImageFile.IsValid(new MockPostedVideoFile());

        //    //Assert
        //    Assert.IsFalse(valid);
        //}

        //    [TestMethod]
        //public void CreateAuctionFailTest()
        //{
        //    //Arrange
        //    AuctionSetUp auctionSetUp = new AuctionSetUp();
        //    auctionSetUp.BidInterval = 20;
        //    auctionSetUp.StartPrice = 500;
        //    auctionSetUp.BuyOutPrice = 550;
        //    auctionSetUp.SelectedCategory = "Bil";
        //    auctionSetUp.EndDate = DateTime.Now;
        //    //auctionSetUp.Description = "Flot bil";


        //    //Act


        //    //Assert
        //    Assert.IsTrue(ValidateModel(auctionSetUp).Any(
        //        v => v.MemberNames.Contains("Description") && 
        //        v.ErrorMessage.Contains("required")));

        //}
        //private IList<ValidationResult> ValidateModel(object model)
        //{
        //    var validationResults = new List<ValidationResult>();
        //    var ctx = new ValidationContext(model, null, null);
        //    Validator.TryValidateObject(model, ctx, validationResults, true);
        //    return validationResults;
        //}


    }
}
