using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Utility
{
    public class CheckDateTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) { return false; }

            DateTime date = Convert.ToDateTime(value);

            if(date > DateTime.Now)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}