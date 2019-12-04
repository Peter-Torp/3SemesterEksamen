using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.Models
{
    [DataContract]
    public class BidData
    {
        [DataMember]
        public int Bid_Id { get; set; }
        [DataMember]
        public int Auction_Id { get; set;  }
        [DataMember]
        public int User_Id { get; set; }
        [DataMember]
        public DateTime Date { get; set;  }
        [DataMember]
        public double Amount { get; set; }
        [DataMember]
        public string UserName { get; set; }
    }
}
