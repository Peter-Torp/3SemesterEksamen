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

        public ActionResult CreateAuction()
        {
            B_AuctionController bACtr = new B_AuctionController();
            AuctionSetUp aSU = new AuctionSetUp();

            //Get categories from DB.
            List<string> categories = bACtr.GetCategories();

            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (string category in categories)
            {
                selectList.Add(new SelectListItem { Value = category, Text = category });
            }
            aSU.Categories = new SelectList(selectList, "Value", "Text");

            return View(aSU);
        }

        public ActionResult AddPictures(int id)
        {
            AuctionPicture auctionPicture = new AuctionPicture();
            auctionPicture.Id = id;

            return View(auctionPicture);
        }

        public ActionResult CreateAuctionDetails(Models.AuctionSetUp auctionDetails)
        {
            if (ModelState.IsValid)
            {
                B_AuctionController bACtr = new B_AuctionController();

                ConvertViewModel converter = new ConvertViewModel();

                bool successful = bACtr.CreateAuction(converter.ConvertFromAuctionSetUpToCreateAuction(auctionDetails, User.Identity.Name));

                if (successful)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Return message to user here if insertion failed.
                }
            }
            else
            {
                return View("CreateAuction");
            }
            return View("CreateAuction");
        }


        public PartialViewResult AddPicturePartial()
        {
            return PartialView("AddPicturePartial");
        }

        public PartialViewResult AddAuctionPartial()
        {
            //var vm = new AuctionSetUp();

            //vm.Categories = new SelectList ( new List<SelectListItem>
            //{
            //                new SelectListItem {Value= vm.SelectedCategory , Text = "Elektronik"},
            //                new SelectListItem {Value = vm.SelectedCategory , Text = "Biler"},
            //                new SelectListItem {Value = vm.SelectedCategory, Text = "Have"}
            //}, "Value", "Text");

            return PartialView("AddAuctionPartial"/*, vm*/);
        }

        public ActionResult InsertPictureDetail(AuctionPicture pictureDetail)
        {
            if (ModelState.IsValid)
            {
                B_AuctionController bACtr = new B_AuctionController();

                ConvertViewModel converter = new ConvertViewModel();

                
            }
            else
            {
                return View("AddPictures");
            }
            return View("AddPictures");
        }

        public ActionResult Auction(int id)
        {
            B_AuctionController bACtr = new B_AuctionController();

            ConvertViewModel converter = new ConvertViewModel();

            AuctionInfoModel auctionInfoModel = converter.ConvertFromAuctionToAuctionModel(bACtr.GetAuction(id));

            /*            //Get picture
                        Stream image = bACtr.GetPicture(User.Identity.Name, id);
                        var fileStreamResult = new FileStreamResult(image, "image/jpeg");
                        ShowAuctionPictureModel aPic = new ShowAuctionPictureModel();
                        aPic.FileStream = fileStreamResult;
                        List<ShowAuctionPictureModel> sAPM = new List<ShowAuctionPictureModel>();
                        sAPM.Add(aPic);*/

            List<ShowAuctionPictureModel> sAPM = converter.ConvertFromImagesToShowAuctionPictureModels(bACtr.GetImages(id));
            sAPM.Add(new ShowAuctionPictureModel { FileName = "image_4.jpg" });
            sAPM.Add(new ShowAuctionPictureModel { FileName = "image_4.jpg" });
            sAPM.Add(new ShowAuctionPictureModel { FileName = "image_1.jpg" });
            sAPM.Add(new ShowAuctionPictureModel { FileName = "image_1.jpg" });
            return View(new AuctionModel(){ AuctionInfoModel = auctionInfoModel,ShowAuctionPictureModels = sAPM});
        }

        public ActionResult AddPictureToMemory(AuctionPicture picture,int id)
        {
            B_AuctionController bACtr = new B_AuctionController();

            //GET ALL PICTURES FROM AUCTION
            if (ModelState.IsValid)
            {
                ConvertViewModel converter = new ConvertViewModel();

                bACtr.InsertPicture(converter.ConvertFromAuctionPictureToImage(picture), User.Identity.Name, id);
            }

            return RedirectToAction("AddPictures", new { id });
            //return View("AddPictures", new { id = id });
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


        public FileStreamResult AuctionShowImage(int id, string fileName)
        {
            B_AuctionController bActr = new B_AuctionController();

            Image image = bActr.GetPicture(User.Identity.Name, id, fileName);

            var fileStreamResult = new FileStreamResult(image.FileStream, "image/jpg");
            fileStreamResult.FileDownloadName = image.FileName;
            return fileStreamResult;
        }
    }
}