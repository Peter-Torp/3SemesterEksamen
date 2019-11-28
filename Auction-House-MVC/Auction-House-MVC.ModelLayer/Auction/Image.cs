using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_MVC.ModelLayer.Auction
{
    public class Image
    {
        public string FileName { get; set; }
        public string Description { get; set; }
        public Stream stream { get; set; }
    }
}
