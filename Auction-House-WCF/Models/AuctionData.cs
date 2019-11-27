using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Models
{
    [DataContract]
    public class AuctionData
    {

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public double StartPrice { get; set; }
        [DataMember]
        public double BuyOutPrice { get; set; }
        [DataMember]
        public double BidInterval { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int UserId { get; set; }

    }
}
