using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction_House_MVC.Models
{
    public class PictureViewModel
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public FileStreamResult FileStream { get; set; }
        public string FileName { get; set; }
    }
}