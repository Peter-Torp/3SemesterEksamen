using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.ModelLayer
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
    }
}