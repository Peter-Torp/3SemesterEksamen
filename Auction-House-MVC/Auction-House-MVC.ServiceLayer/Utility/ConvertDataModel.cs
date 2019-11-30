using Auction_House_MVC.ModelLayer;
using Auction_House_MVC.ModelLayer.Auction;
using Auction_House_MVC.ServiceLayer.AuctionServiceReference;
using Auction_House_MVC.ServiceLayer.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.ServiceLayer.Utility
{
    public class ConvertDataModel
    {
        public AuctionData ConvertFromCreateAuctionToAuctionData(CreateAuction createAuction)
        {
            AuctionData aD = new AuctionData
            {
                UserName = createAuction.UserName,
                StartPrice = createAuction.StartPrice,
                BuyOutPrice = createAuction.BuyOutPrice,
                BidInterval = createAuction.BidInterval,
                Description = createAuction.Description,
                EndDate = createAuction.EndDate,
                Category = createAuction.Category
            };
            return aD;
        }

        /// <summary>
        /// Converts UserData from service to modellayer userlogin.
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        public UserLogin ConvertFromUserDataToLogin(UserData userData)
        {
            UserLogin userLogin = new UserLogin
            {
                Id = userData.Id,
                Salt = userData.Salt,
                Hash = userData.PasswordHash
            };
            return userLogin;
        }

        /// <summary>
        /// Converts UserData from servicelayer to modellayer user.
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        public User ConvertFromUserDataToUser(UserData userData)
        {
            User user = new User
            {
                Id = userData.Id,
                UserName = userData.UserName,
                Email = userData.Email,
                Phone = userData.Phone,
                ZipCode = userData.ZipCode,
                Region = userData.Region
            };
            return user;
        }

        public ImageData[] ConvertFromImagesToImageData(List<Image> images)
        {
            ImageData[] imageData = new ImageData[images.Count];
            int i = 0;
            foreach(Image image in images)
            {
                ImageData imageD = new ImageData
                {
                    AuctionId = image.AuctionId,
                    UserId = image.UserId,
                    Description = image.Description,
                    FileName = image.FileName,
                    FileStream = image.FileStream
                };
                imageData[i] = imageD;
                i++;
            }
            return imageData;
        }

        public ImageData1 ConvertFromImageToImageData(Image image)
        {

                ImageData1 imageD = new ImageData1
                {
                    AuctionId = image.AuctionId,
                    UserId = image.UserId,
                    Description = image.Description,
                    FileName = image.FileName,
                    FileStream = image.FileStream
                };

            return imageD;
        }

    }
}