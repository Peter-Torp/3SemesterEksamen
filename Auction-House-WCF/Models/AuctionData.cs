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
        public int Id { get; set; }         //1
        [DataMember]
        public double StartPrice { get; set; }      //2
        [DataMember]
        public double BuyOutPrice { get; set; }     //3
        [DataMember]
        public double BidInterval { get; set; }     //4
        [DataMember]
        public string Description { get; set; }     //5
        [DataMember]
        public DateTime StartDate { get; set; }     //6
        [DataMember]
        public DateTime EndDate { get; set; }       //7
        [DataMember]
        public string Category { get; set; }        //8
        [DataMember]
        public string UserName { get; set; }        //9
        [DataMember]
        public int UserId { get; set; }     //10
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public string Region { get; set; }
    }
}
