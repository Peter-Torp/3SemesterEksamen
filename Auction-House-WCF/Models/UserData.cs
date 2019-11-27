using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Auction_House_WCF.Models
{
    [DataContract]
    public class UserData : IPerson
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public string PasswordHash { get; set; }
        [DataMember]
        public string Salt { get; set; }
    }
}