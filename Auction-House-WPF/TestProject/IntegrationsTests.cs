using Auction_House_WPF.Model;
using Auction_House_WPF.ModelLayer;
using Auction_House_WPF.ServiceLayer;
using Auction_House_WPF.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using RepositoryLayer;
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
        AuctionModel TestAuctionModel;
        FirstChildViewModel firstChildViewModel;
        UserModel userModel;
        AuctionService auctionService;
        AuctionRepos auctionRepos;
        UserService userService;


       [TestInitialize]
        public void ArrangeBeforeEachTest()
        {
            secondChildViewModel = new SecondChildViewModel();
            firstChildViewModel = new FirstChildViewModel();
            auctionService = new AuctionService();
            auctionRepos = new AuctionRepos();
            userService = new UserService();
        }

        [TestMethod]
        public void GetUserByUserName()
        {
            //Arrange
            string testInput = "Jørgen";
            //Act
            secondChildViewModel.SearchUserByUserName(testInput);
            //Assert
            Assert.AreEqual(1, secondChildViewModel.UserShowModel.Count);
        }

        [TestMethod]        //ret så den ikke opretter et objekt uden grund
        public void TryGetUserByUserNameInvalid()
        {
            //Arrange
            string testInput = "AWDSAWDS";
            //Act
            secondChildViewModel.SearchUserByUserName(testInput);
            //Assert
            Assert.AreEqual(0, secondChildViewModel.UserShowModel.Count);   //test should give 1. But object properties are null.
        }

        [TestMethod] 
        public void DeleteAuction()
        {
            //Arrange
            userModel = new UserModel("Peter","Torp","TheDankMan","Dudududuvej","Pepe@meme.dk","99887766","9876","2008");
            TestAuctionModel = new AuctionModel(50,500,1500,50,"Lækker lækker MacDut",DateTime.Now,DateTime.Today,"Hjemløs","TheDankMan");
            //Act
            userService.CreateUser(userModel);
            auctionService.CreateAuction(TestAuctionModel,userModel);
            auctionRepos.deleteAuctionById(TestAuctionModel.Id);
            
            //Assert
            Assert.IsNull(auctionRepos.getAuctionsByUserName("TheDankMan"));
        }


        [TestCleanup]
        public void TestCleanUp()
        {
            secondChildViewModel = null;
            
        }


    }
}
