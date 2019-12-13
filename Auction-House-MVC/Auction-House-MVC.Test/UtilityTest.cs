using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_MVC.Utility;
using System.Web;

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

    }
}
