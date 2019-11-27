﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace Auction_House_MVC.Models
{
    public class UserSignUpModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter username.")]
        [StringLength(30, MinimumLength = 3)]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required]
        //[RegularExpression("")]
        [EmailAddress]
        [DisplayName("E-mail address")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Phone number")]
        public string Phone { get; set; }

        [Required]
        [DisplayName("Zip code")]
        public string ZipCode { get; set; }

        [Required]
        [DisplayName("Region")]
        public string Region { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Password")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password does not contain atleast one of the following: a number, uppercase letter or lowercase letter.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password does not match.")]
        [Display(Name= "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}