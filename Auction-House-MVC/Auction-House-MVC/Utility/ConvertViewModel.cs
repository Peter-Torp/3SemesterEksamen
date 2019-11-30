using Auction_House_MVC.ModelLayer;
using Auction_House_MVC.Models;
using Auction_House_MVC.ModelLayer.Auction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Utility
{
    public class ConvertViewModel : IViewModel
    {
        /// <summary>
        /// Converts UserSignUpModel to UserSignUp.
        /// </summary>
        /// <param name="uSUModel"></param>
        /// <returns></returns>
        public UserSignUp ConvertFromUserSignUpModelToSignUp(UserSignUpModel uSUModel)
        {
            UserSignUp uSU = new UserSignUp
            {
                UserName = uSUModel.UserName,
                Email = uSUModel.Email,
                Phone = uSUModel.Phone,
                ZipCode = uSUModel.ZipCode,
                Region = uSUModel.Region,
                Password = uSUModel.Password
            };
            return uSU;
        }

        public UserShowModel ConvertFromUserToUserShowModel(User user)
        {
            UserShowModel uSM = new UserShowModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.Phone,
                Region = user.Region,
                ZipCode = user.ZipCode
            };
            return uSM;
        }

        public CreateAuction ConvertFromAuctionSetUpToCreateAuction(AuctionSetUp aSU, string userName)
        {
            CreateAuction cA = new CreateAuction
            {
                UserName = userName,
                StartPrice = aSU.StartPrice,
                BuyOutPrice = aSU.BuyOutPrice,
                BidInterval = aSU.BidInterval,
                Description = aSU.Description,
                EndDate = aSU.EndDate,
                Category = aSU.SelectedCategory
            };
            return cA;
        }

        public List<Image> ConvertFromAuctionPicturesToImages(List<AuctionPicture> auctionPictures)
        {
            List<Image> images = new List<Image>();
            foreach (AuctionPicture aPic in auctionPictures)
            {
                Image image = new Image
                {
                    Description = aPic.Description,
                    FileName = aPic.FileName,
                    FileStream = aPic.FileStream.InputStream
                };
                images.Add(image);
            }
            return images;
        }

        public Image ConvertFromAuctionPictureToImage(AuctionPicture aPic)
        {

                Image image = new Image
                {
                    Description = aPic.Description,
                    FileName = aPic.FileStream.FileName,
                    FileStream = aPic.FileStream.InputStream
                };
            return image;
        }
    }
}