using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Models
{
    [MessageContract]
    public class DownloadRequest
    {
        [MessageBodyMember]
        public string FileName { get; set; }
        [MessageBodyMember]
        public int UserId { get; set; }
        [MessageBodyMember]
        public int AuctionNumber { get; set; }
    }
}
