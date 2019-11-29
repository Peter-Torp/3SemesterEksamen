using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Models
{
    [DataContract]
    public class ImageData
    {
        [DataMember]
        public int AuctionId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string ImgUrl { get; set; }
        [DataMember]
        public DateTime DateAdded { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public Stream FileStream { get; set; }
    }
}
