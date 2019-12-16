using Auction_House_MVC.BusinessLayer;
using Auction_House_MVC.ModelLayer;
using Auction_House_MVC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Auction_House_MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveSignUpDetails(Models.UserSignUpModel userDetails)
        {
            if (ModelState.IsValid)
            {
                B_UserController bUCtr = new B_UserController();

                ConvertViewModel converter = new ConvertViewModel();
                
                bool successful = bUCtr.SignUp(converter.ConvertFromUserSignUpModelToSignUp(userDetails));

                if (successful)
                {
                    FormsAuthentication.SetAuthCookie(userDetails.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Return message to user here if insertion failed.
                }
            }
            return View("SignUp");
        }

        public ActionResult MyAccount()
        {
            return View();
        }

        public ActionResult UserInfoPartial(Models.UserViewModel userDetails)
        {
            B_UserController bUCtr = new B_UserController();
            User user = bUCtr.GetUserByUserName(User.Identity.Name);
            userDetails.UserName = user.UserName;
            userDetails.Email = user.Email;
            userDetails.Phone = user.Phone;
            userDetails.ZipCode = user.ZipCode;
            userDetails.Region = user.Region;
            return PartialView(userDetails);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }


        public ActionResult LogInDetails(Models.LogInModel loginDetails)
        {
            ViewBag.LoginFailed = false;

            if (ModelState.IsValid)
            {
                B_UserController bUCtr = new B_UserController();
                bool authenticated = bUCtr.Login(loginDetails.UserName, loginDetails.Password);
                if (authenticated)
                {
                    FormsAuthentication.SetAuthCookie(loginDetails.UserName, false);
                }
                else
                {
                    // Error message - Wrong credentials
                    ViewBag.LoginFailed = true;
                    ModelState.AddModelError("error_msg", "Wrong credentials");
                    return View("LogIn");
                }
                return RedirectToAction("Index", "Home");
            }
            return View("LogIn");
        }

        public ActionResult LogIn()
        {
            ViewBag.LoginFailed = false;
            return View();
        }
    }
}