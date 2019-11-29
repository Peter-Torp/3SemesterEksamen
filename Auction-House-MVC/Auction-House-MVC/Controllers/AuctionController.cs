using Auction_House_MVC.BusinessLayer;
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

        // GET: Auction  

        public ActionResult Auction()
        {
            return View();
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

        //public ActionResult ShowAuctions()
        //{
        //    B_AuctionController bActr = new B_AuctionController();

        //    return View();
        //}



        public FileStreamResult AuctionShowImage()
        {
            B_AuctionController bActr = new B_AuctionController();

            Stream image = bActr.GetPicture(User.Identity.Name, 1);

            var fileStreamResult = new FileStreamResult(image, "image/jpeg");

            return fileStreamResult;
        }
    }
}