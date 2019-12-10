using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Models
{
    public class SearchModel
    {
        [Required(ErrorMessage = "Please enter search parameter")]
        [DisplayName("Search auctions")]
        public string SearchString { get; set; }
    }
}