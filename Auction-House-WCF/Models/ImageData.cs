using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Models
{
    [MessageContract]
    public class ImageData
    {
        [MessageHeader]
        public int AuctionId { get; set; }
        [MessageHeader]
        public int UserId { get; set; }
        [MessageHeader]
        public string ImgUrl { get; set; }
        [MessageHeader]
        public DateTime DateAdded { get; set; }
        [MessageHeader]
        public string Description { get; set; }
        [MessageHeader]
        public string FileName { get; set; }
        [MessageBodyMember]
        public Stream FileStream { get; set; }
    }
}
