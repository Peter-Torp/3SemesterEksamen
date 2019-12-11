using Auction_House_MVC.BusinessLayer;
using Auction_House_MVC.ModelLayer.Auction;
using Auction_House_MVC.Models;
using Auction_House_MVC.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction_House_MVC.Controllers
{

    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyAuctions()
        {
            return View();
        }

        [Authorize]
        public ActionResult CreateAuction()
        {
            B_AuctionController bACtr = new B_AuctionController();
            AuctionSetUp aSU = new AuctionSetUp();

            //Get categories from database.
            List<SelectListItem> selectList = GetCategoriesAndConvertToSelectListItem();

            aSU.Categories = new SelectList(selectList, "Value", "Text");

            return View(aSU);
        }

        private List<SelectListItem> GetCategoriesAndConvertToSelectListItem()
        {
            B_AuctionController bACtr = new B_AuctionController();
            List<string> categories = bACtr.GetCategories();

            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (string category in categories)
            {
                selectList.Add(new SelectListItem { Value = category, Text = category });
            }
            return selectList;
        }

        public ActionResult AddPictures(int id)
        {
            AuctionPicture auctionPicture = new AuctionPicture();
            auctionPicture.Id = id;

            return View(auctionPicture);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult CreateAuctionDetails(Models.AuctionSetUp auctionDetails)
        {
            if (ModelState.IsValid)
            {
                B_AuctionController bACtr = new B_AuctionController();

                ConvertViewModel converter = new ConvertViewModel();

                bool successful = bACtr.CreateAuction(converter.ConvertFromAuctionSetUpToCreateAuction(auctionDetails, User.Identity.Name));

                if (successful)
                {
                    TempData["Referer"] = "AuctionSuccessful";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Referer"] = "AuctionFailed";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                List<SelectListItem> selectList = GetCategoriesAndConvertToSelectListItem();

                auctionDetails.Categories = new SelectList(selectList, "Value", "Text");
            }
            return View("CreateAuction", auctionDetails);
        }


        public PartialViewResult AddPicturePartial()
        {
            return PartialView("AddPicturePartial");
        }

        public PartialViewResult AddAuctionPartial()
        {
            return PartialView("AddAuctionPartial");
        }

        public ActionResult Auction(int id)
        {
            B_AuctionController bACtr = new B_AuctionController();

            ConvertViewModel converter = new ConvertViewModel();

            //Auction details from database.
            AuctionInfoModel auctionInfoModel = converter.ConvertFromAuctionToAuctionModel(bACtr.GetAuction(id));

            if (auctionInfoModel == null)
            {
                return View("NotFound");
            }

            //Get Images info from database.
            List<ShowAuctionPictureModel> sAPM = converter.ConvertFromImagesToShowAuctionPictureModels(bACtr.GetImages(id));

            //Get bids on the auction from database.
            List<ShowBid> showBids = converter.ConvertFromBidsToShowBids(bACtr.GetBids(id));

            //Get highest bid from database - Create insert bids model
            InsertBidModel insertBidModel = new InsertBidModel();
            insertBidModel.CurrentHighestBid = bACtr.GetHighestBidOnAuction(id);
            insertBidModel.MinimumValidBid = insertBidModel.CurrentHighestBid + auctionInfoModel.BidInterval;

            //Return the AuctionModel
            return View(new AuctionModel() { AuctionInfoModel = auctionInfoModel, ShowAuctionPictureModels = sAPM, ShowBids = showBids, InsertBidModel = insertBidModel });
        }

        [Authorize]
        public ActionResult AddPictureDetails(AuctionPicture picture, int id)
        {
            B_AuctionController bACtr = new B_AuctionController();

            //GET ALL PICTURES FROM AUCTION
            if (ModelState.IsValid)
            {
                string extension = Path.GetExtension(picture.FileStream.FileName);

                // Check file type and length - Getting pictures is limited to 40kb for some reason, so upload is limited.
                if (picture.FileStream.ContentLength < 40000)
                {
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".jfif")
                    {
                        ConvertViewModel converter = new ConvertViewModel();

                        bACtr.InsertPicture(converter.ConvertFromAuctionPictureToImage(picture), User.Identity.Name, id);

                        TempData["Referer"] = "PictureSuccessful";
                    }
                    else
                    {
                        TempData["Referer"] = "PictureFailed";
                    }
                }
                else
                {
                    TempData["Referer"] = "PictureFailed";
                }
            }
            return RedirectToAction("AddPictures", new { id });
        }

        //public ActionResult ShowAuctions()
        //{
        //    B_AuctionController bActr = new B_AuctionController();

        //    return View();
        //}

        public ActionResult AuctionsPartial()
        {
            B_AuctionController bACtr = new B_AuctionController();

            ConvertViewModel converter = new ConvertViewModel();

            List<Auction> auctions = bACtr.GetUserAuctions(User.Identity.Name);

            List<AuctionInfoModel> auctionModels = converter.ConvertFromAuctionsToAuctionModels(auctions);

            return View(auctionModels);
        }

        public ActionResult LatestAuctionsPartial()
        {
            B_AuctionController bACtr = new B_AuctionController();

            ConvertViewModel converter = new ConvertViewModel();

            List<Auction> auctions = bACtr.GetLatestAuctions();

            List<AuctionInfoModel> auctionModels = converter.ConvertFromAuctionsToAuctionModels(auctions);

            return View("AuctionsPartial", auctionModels);
        }

        public ActionResult SearchAuctionsResult(SearchModel searchModel)
        {
            return View(searchModel);
        }

        public ActionResult SearchAuctionsPartial()
        {
            return View();
        }

        public ActionResult SearchAuctionsDetails(SearchModel searchDetails)
        {
            B_AuctionController bACtr = new B_AuctionController();
            ConvertViewModel converter = new ConvertViewModel();

            List<AuctionInfoModel> auctionModels = converter.ConvertFromAuctionsToAuctionModels(bACtr.GetAuctionsByDesc(searchDetails.SearchString));
            return View("AuctionsPartial", auctionModels);
        }

        public FileStreamResult AuctionShowImage(int id, string fileName, string userName)
        {
            B_AuctionController bActr = new B_AuctionController();

            Image image = bActr.GetPicture(userName, id, fileName);

            string imageType = "image/" + Path.GetExtension(fileName).Replace(".", "");

            var fileStreamResult = new FileStreamResult(image.FileStream, imageType);
            fileStreamResult.FileDownloadName = image.FileName;

            return fileStreamResult;
        }

        public ActionResult ShowBids(List<ShowBid> showBids)
        {
            return View("ShowBids", showBids);
        }

        [Authorize]
        public ActionResult InsertBid(InsertBidModel insertBidModel, int id)
        {
            insertBidModel.AuctionId = id;
            return View("InsertBid", insertBidModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult InsertBidDetail(InsertBidModel insertBid, int id)
        {
            bool successful = false;
            if (ModelState.IsValid)
            {
                B_AuctionController bACtr = new B_AuctionController();

                ConvertViewModel converter = new ConvertViewModel();

                successful = bACtr.InsertBid(converter.ConvertFromBidInsertModelToBid(insertBid, User.Identity.Name, id));

                //For messages to the user.
                if (successful)
                {
                    TempData["Referer"] = "InsertSuccessful";
                }
                else
                {
                    TempData["Referer"] = "InsertFailed";
                }
            }

            return RedirectToAction("Auction", new { id });
        }
    }
}