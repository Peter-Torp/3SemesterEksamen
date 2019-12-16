using Auction_House_MVC.ModelLayer;
using Auction_House_MVC.Models;
using Auction_House_MVC.ModelLayer.Auction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction_House_MVC.ModelLayer.Bid;

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

        public UserViewModel ConvertFromUserToUserShowModel(User user)
        {
            UserViewModel uSM = new UserViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.Phone,
                Region = user.Region,
                ZipCode = user.ZipCode
            };
            return uSM;
        }

        public CreateAuction ConvertFromAuctionSetUpToCreateAuction(AuctionSetUpModel aSU, string userName)
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

        public List<Image> ConvertFromAuctionPicturesToImages(List<InsertPictureModel> auctionPictures)
        {
            List<Image> images = new List<Image>();
            foreach (InsertPictureModel aPic in auctionPictures)
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

        public Image ConvertFromAuctionPictureToImage(InsertPictureModel aPic)
        {

            Image image = new Image
            {
                Description = aPic.Description,
                FileName = aPic.FileStream.FileName,
                FileStream = aPic.FileStream.InputStream
            };
            return image;
        }

        public List<AuctionInfoViewModel> ConvertFromAuctionsToAuctionModels(List<Auction> auctions)
        {
            List<AuctionInfoViewModel> auctionModels = new List<AuctionInfoViewModel>();
            foreach (Auction auction in auctions)
            {
                AuctionInfoViewModel auctionModel = ConvertFromAuctionToAuctionModel(auction);
                auctionModels.Add(auctionModel);
            }
            return auctionModels;
        }

        public AuctionInfoViewModel ConvertFromAuctionToAuctionModel(Auction auction)
        {
            if (auction != null)
            {
                AuctionInfoViewModel auctionModel = new AuctionInfoViewModel
                {
                    StartPrice = auction.StartPrice,
                    BuyOutPrice = auction.BuyOutPrice,
                    BidInterval = auction.BidInterval,
                    Description = auction.Description,
                    StartDate = auction.StartDate,
                    EndDate = auction.EndDate,
                    Category = auction.Category,
                    UserName = auction.UserName,
                    Id = auction.Id,
                    UserLocation = auction.ZipCode + " - " + auction.Region
                };

                return auctionModel;
            }
            else
            {
                return null;
            }
        }

        public PictureViewModel ConvertFromImageToShowAuctionPictureModel(Image image)
        {
            PictureViewModel sAPM = new PictureViewModel()
            {
                FileName = image.FileName,
                Description = image.Description
            };
            return sAPM;
        }

        public List<PictureViewModel> ConvertFromImagesToShowAuctionPictureModels(List<Image> images)
        {
            List<PictureViewModel> lSAPM = new List<PictureViewModel>();
            foreach (Image image in images)
            {
                lSAPM.Add(ConvertFromImageToShowAuctionPictureModel(image));
            }
            return lSAPM;
        }

        public BidViewModel ConvertFromBidToShowBid(Bid bid)
        {
            BidViewModel showBid = new BidViewModel
            {
                Amount = bid.Amount,
                Date = bid.Date,
                UserName = bid.UserName
            };
            return showBid;
        }
        public List<BidViewModel> ConvertFromBidsToShowBids(List<Bid> bids)
        {
            List<BidViewModel> showBids = new List<BidViewModel>();
            foreach (Bid bid in bids)
            {
                showBids.Add(ConvertFromBidToShowBid(bid));
            }
            return showBids;
        }

        public Bid ConvertFromBidInsertModelToBid(InsertBidModel iBM, string userName, int auctionId)
        {
            Bid bid = new Bid
            {
                Auction_Id = auctionId,
                Amount = iBM.Amount,
                UserName = userName
            };
            return bid;
        }
    }
}