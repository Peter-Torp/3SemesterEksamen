using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Utility
{
    public class CheckBuyOutIsHigherThanStartPrice : ValidationAttribute
    {
        private readonly string propertyNameToCheck;

        public CheckBuyOutIsHigherThanStartPrice(string propertyNameToCheck)
        {
            this.propertyNameToCheck = propertyNameToCheck;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectInstance.GetType().GetProperty(propertyNameToCheck);
            var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance, null);

            if ((double) otherPropertyValue < (double)value)
            {
                return ValidationResult.Success;
            } else
            {
                return new ValidationResult("Buy Out is not higher than Start Price");
            }
        }
    }
}