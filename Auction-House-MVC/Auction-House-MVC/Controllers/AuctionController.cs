using Auction_House_MVC.BusinessLayer;
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
            //GET CATEGORIES FROM DB
            string[] categories = { "Elektronik", "Biler", "Have" };
            ViewBag.Category = categories;
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
            return View("CreateAuction");
        }

        public ActionResult Auction()
        {
            return View();
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