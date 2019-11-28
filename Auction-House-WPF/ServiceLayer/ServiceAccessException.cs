using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WPF.ServiceAccessExceptions
{
    public class ServiceAccessException : Exception
    {
        public ServiceAccessException(string message) : base(message)
        {
        }


    }
}