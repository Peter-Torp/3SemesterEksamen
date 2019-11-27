using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Models
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Please enter username.")]
        [DisplayName("User name")]
        public string UserName { set; get; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { set; get; }
    }
}