using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Models
{
    public class Login
    {
        public string password { get; set; }
        public string salt { get; set; }
        
        public Login(string password, string salt)
        {
            this.password = password;
            this.salt = salt;
          
        }


    }
}
