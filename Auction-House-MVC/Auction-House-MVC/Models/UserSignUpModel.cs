using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using Auction_House_MVC.Utility;

namespace Auction_House_MVC.Models
{
    public class UserSignUpModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter username.")]
        [StringLength(30, MinimumLength = 3)]
        [DisplayName("User name")]
        [CheckExistingUserName(ErrorMessage = "User name is taken!")]
        public string UserName { get; set; }

        [Required]
        //[RegularExpression("")]
        [EmailAddress]
        [StringLength(50)]
        [DisplayName("E-mail address")]
        public string Email { get; set; }

        [Required]
        [StringLength(26)]
        [DisplayName("Phone number")]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Zip code")]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DisplayName("Region")]
        public string Region { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Password", Description = "Password must contain: a number, an uppercase letter, lowercase letter and be 8 characters long. ")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", 
            ErrorMessage = "Password does not contain atleast one of the following: a number, an uppercase letter and a lowercase letter.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password does not match.")]
        [Display(Name= "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}