using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Models
{
    public class AuctionPicture
    {
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Upload image")]
        [Required(ErrorMessage = "Choose an image")]
        public HttpPostedFileBase FileStream { get; set; }
        public string FileName { get; set; }
    }
}