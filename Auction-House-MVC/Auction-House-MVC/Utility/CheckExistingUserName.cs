using Auction_House_MVC.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Utility
{
    public class CheckExistingUserName : ValidationAttribute
    {
        private readonly B_UserController _bBUctr = new B_UserController();

        /// <summary>
        /// Checks if username exist in Database
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if(value == null) { return false; }

            string userName = value.ToString();

            bool found = _bBUctr.CheckUserName(userName);

            return !found; 
        }

    }
}