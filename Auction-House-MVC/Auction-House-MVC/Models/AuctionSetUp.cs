using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction_House_MVC.Utility;

namespace Auction_House_MVC.Models
{
    public class AuctionSetUp
    {
        [DisplayName("Start price")]
        [Range(0.0, Double.MaxValue)]
        [Required]
        public double StartPrice { get; set; }
        [DisplayName("Buy out price")]
        [Range(0.0, Double.MaxValue)]
        [Required]
        [CheckBuyOutIsHigherThanStartPrice("StartPrice")] // Custome made data annotation - In Utility
        public double BuyOutPrice { get; set; }
        [DisplayName("Bid interval")]
        [Range(0.0, Double.MaxValue)]
        [Required]
        public double BidInterval { get; set; }
        [DisplayName("Description")]
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("End date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [CheckDateTime(ErrorMessage = "Date has to be after current time.")] // Custome made data annotation - In Utility
        public DateTime EndDate { get; set; }
        [DisplayName("Category")]
        [Required(ErrorMessage = "Please choose category")]
        public string SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public IEnumerable<AuctionPicture> Pictures { get; set; }
    }
}