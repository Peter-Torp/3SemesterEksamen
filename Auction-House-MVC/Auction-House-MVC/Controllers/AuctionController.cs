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
            AuctionSetUp aSU = new AuctionSetUp();
             aSU.Categories = new SelectList(new List<SelectListItem>
            {
                            new SelectListItem {Value= "Elektronik" , Text = "Elektronik"},
                            new SelectListItem {Value = "Biler" , Text = "Biler"},
                            new SelectListItem {Value = "Have", Text = "Have"}
            }, "Value", "Text");

            return View(aSU);
        }

        public ActionResult AddPictures()
        {
            //TODO: GET AUCTION ID
            int auctionId = 5;
            ViewBag.AuctionId = auctionId;
            return View();
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

            AuctionModel auctionModel = converter.ConvertFromAuctionToAuctionModel(bACtr.GetAuction(id));

            return View(auctionModel);
        }

        public ActionResult AddPictureToMemory(AuctionPicture picture)
        {
            B_AuctionController bACtr = new B_AuctionController();
            //TODO: GET AUCTION ID
            int auctionId = 5;
            ViewBag.AuctionId = auctionId;

            //GET ALL PICTURES FROM AUCTION
            if (ModelState.IsValid)
            {
                ConvertViewModel converter = new ConvertViewModel();

                bACtr.InsertPicture(converter.ConvertFromAuctionPictureToImage(picture), User.Identity.Name, auctionId);
            }
            return View("AddPictures");
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

            List<AuctionModel> auctionModels = converter.ConvertFromAuctionsToAuctionModels(auctions);

            return View(auctionModels);
        }


        public FileStreamResult AuctionShowImage()
        {
            B_AuctionController bActr = new B_AuctionController();

            Stream image = bActr.GetPicture(User.Identity.Name, 1);

            var fileStreamResult = new FileStreamResult(image, "image/jpeg");

            return fileStreamResult;
        }
    }
}