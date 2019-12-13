using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Auction_House_MVC.Utility
{
    public class CheckImageFile : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) { return false; }

            HttpPostedFileWrapper file = (HttpPostedFileWrapper) value;

            bool validExtension = CheckExtension(file);
            bool validFileSize = CheckFileSize(file);

            if(validExtension && validFileSize)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        private bool CheckExtension(HttpPostedFileWrapper file)
        {
            string extension = Path.GetExtension(file.FileName);

            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".jfif")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Check file type and length - Getting pictures is limited to 40kb for some reason, so upload is limited.
        private bool CheckFileSize(HttpPostedFileWrapper file)
        {
            if (file.ContentLength < 40000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}