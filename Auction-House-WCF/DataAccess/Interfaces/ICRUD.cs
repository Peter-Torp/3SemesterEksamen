using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WCF.DataAccess.Interfaces
{
    interface ICRUD<T>
    {
        int Create(T entity);
        T Get(int id);
    }
}
