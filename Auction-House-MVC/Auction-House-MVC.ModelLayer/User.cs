using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.ModelLayer
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public string Region { get; set; }
    }
}