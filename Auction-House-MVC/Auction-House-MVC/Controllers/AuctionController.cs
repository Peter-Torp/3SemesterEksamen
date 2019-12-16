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

        /// <summary>
        /// Shows the create auction view, and adds categories to dropdownlist.
        /// </summary>
        /// <returns>View(AuctionSetUp</returns>
        [Authorize]
        public ActionResult CreateAuction()
        {
            AuctionSetUpModel aSU = new AuctionSetUpModel();

            //Get categories from database.
            List<SelectListItem> selectList = GetCategoriesAndConvertToSelectListItem();

            aSU.Categories = new SelectList(selectList, "Value", "Text");

            return View(aSU);
        }

        /// <summary>
        /// Gets categories from DB and converts them to list of selectlistitems.
        /// </summary>
        /// <returns></returns>
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

        [Authorize]
        public ActionResult AddPictures(int id, string userName)
        {
            // If user is not the same as the owner of the auction.
            if (User.Identity.Name.Equals(userName)) {
                InsertPictureModel auctionPicture = new InsertPictureModel();
                auctionPicture.Id = id;

                return View(auctionPicture);
            } else
            {
                return View("NotFound");
            }
        }

        /// <summary>
        /// Checks if inserted auction details are valid. If so, 
        /// inserts auction to DB.
        /// </summary>
        /// <param name="auctionDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult CreateAuctionDetails(Models.AuctionSetUpModel auctionDetails)
        {
            if (ModelState.IsValid)
            {
                B_AuctionController bACtr = new B_AuctionController();

                ConvertViewModel converter = new ConvertViewModel();

                bool successful = bACtr.CreateAuction(converter.ConvertFromAuctionSetUpToCreateAuction(auctionDetails, User.Identity.Name));

                if (successful)
                {
                    //Sends message to user about auction was created.
                    TempData["Referer"] = "AuctionSuccessful";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Sends message to user about auction was not created.
                    TempData["Referer"] = "AuctionFailed";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                //If modelstate invalid get categories again, so it can be passed down to View again.
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

        /// <summary>
        /// Shows the auction view,
        /// where ViewModel of AuctionModel is used as container for 4 different models.
        /// Shows all the models in one view. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Auction(int id)
        {
            B_AuctionController bACtr = new B_AuctionController();

            ConvertViewModel converter = new ConvertViewModel();

            //Auction details from database.
            AuctionInfoViewModel auctionInfoModel = converter.ConvertFromAuctionToAuctionModel(bACtr.GetAuction(id));

            //If auction is not in database - For handling if users put in illegal auction id in url.
            if (auctionInfoModel == null)
            {
                return View("NotFound");
            }

            //Get Images info from database.
            List<PictureViewModel> sAPM = converter.ConvertFromImagesToShowAuctionPictureModels(bACtr.GetImages(id));

            //Get bids on the auction from database.
            List<BidViewModel> showBids = converter.ConvertFromBidsToShowBids(bACtr.GetBids(id));

            //Get highest bid from database - Create insert bids model
            InsertBidModel insertBidModel = new InsertBidModel();
            insertBidModel.CurrentHighestBid = bACtr.GetHighestBidOnAuction(id);
            insertBidModel.MinimumValidBid = insertBidModel.CurrentHighestBid + auctionInfoModel.BidInterval;

            //Return the AuctionModel
            return View(new AuctionViewModel() { AuctionInfoModel = auctionInfoModel, PictureViewModels = sAPM, ShowBids = showBids, InsertBidModel = insertBidModel });
        }

        /// <summary>
        /// Adds picture details to database and folder.
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddPictureDetails(InsertPictureModel picture, int id)
        {
            B_AuctionController bACtr = new B_AuctionController();

            //GET ALL PICTURES FROM AUCTION
            if (ModelState.IsValid)
            {
                ConvertViewModel converter = new ConvertViewModel();

                bACtr.InsertPicture(converter.ConvertFromAuctionPictureToImage(picture), User.Identity.Name, id);

                TempData["Referer"] = "PictureSuccessful";

            }
            else
            {
                TempData["Referer"] = "PictureFailed";
            }
            return RedirectToAction("AddPictures", new { id });
        }

        /// <summary>
        /// Shows a partial view of auctions for logged in user.
        /// </summary>
        /// <returns></returns>
        public ActionResult MyAuctionsPartial()
        {
            B_AuctionController bACtr = new B_AuctionController();

            ConvertViewModel converter = new ConvertViewModel();

            List<Auction> auctions = bACtr.GetUserAuctions(User.Identity.Name);

            List<AuctionInfoViewModel> auctionModels = converter.ConvertFromAuctionsToAuctionModels(auctions);

            return View("AuctionsPartial", auctionModels);
        }

        /// <summary>
        /// Shows a partial view of latest created auctions.
        /// </summary>
        /// <returns></returns>
        public ActionResult LatestAuctionsPartial()
        {
            B_AuctionController bACtr = new B_AuctionController();

            ConvertViewModel converter = new ConvertViewModel();

            List<Auction> auctions = bACtr.GetLatestAuctions();

            List<AuctionInfoViewModel> auctionModels = converter.ConvertFromAuctionsToAuctionModels(auctions);

            return PartialView("AuctionsPartial", auctionModels);
        }

        /// <summary>
        /// Parent view for SearchAuctionDetails(), which shows auctions.
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public ActionResult SearchAuctionsResult(SearchModel searchModel)
        {
            if (ModelState.IsValid)
            {
                return View(searchModel);
            }
            return View("Index");
        }

        public ActionResult SearchAuctionsPartial()
        {
            return PartialView("SearchAuctionsPartial");
        }

        /// <summary>
        /// Shows view of auctions that was searched for.
        /// </summary>
        /// <param name="searchDetails"></param>
        /// <returns></returns>
        public ActionResult SearchAuctionsDetails(SearchModel searchDetails)
        {
            B_AuctionController bACtr = new B_AuctionController();
            ConvertViewModel converter = new ConvertViewModel();

            List<AuctionInfoViewModel> auctionModels = converter.ConvertFromAuctionsToAuctionModels(bACtr.GetAuctionsByDesc(searchDetails.SearchString));
            return View("AuctionsPartial", auctionModels);
        }

        /// <summary>
        /// Shows an image.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileName"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public FileStreamResult AuctionShowImage(int id, string fileName, string userName)
        {
            B_AuctionController bActr = new B_AuctionController();

            Image image = bActr.GetPicture(userName, id, fileName);

            string imageType = "image/" + Path.GetExtension(fileName).Replace(".", "");

            var fileStreamResult = new FileStreamResult(image.FileStream, imageType);
            fileStreamResult.FileDownloadName = image.FileName;

            return fileStreamResult;
        }

        /// <summary>
        /// Shows view of showbids from List.
        /// </summary>
        /// <param name="showBids"></param>
        /// <returns></returns>
        public ActionResult ShowBids(List<BidViewModel> showBids)
        {
            return View("ShowBids", showBids);
        }

        /// <summary>
        /// Show view for insert bid.
        /// </summary>
        /// <param name="insertBidModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult InsertBid(InsertBidModel insertBidModel, int id)
        {
            insertBidModel.AuctionId = id;
            return View("InsertBid", insertBidModel);
        }

        /// <summary>
        /// Check if bid is valid clientside. Insert it into database. 
        /// If another user was faster, serverside, will return message that bid failed.
        /// If bid was inserted successfully, will return message bid was registered.
        /// </summary>
        /// <param name="insertBid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult InsertBidDetail(InsertBidModel insertBid, int id)
        {
            bool successful;
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