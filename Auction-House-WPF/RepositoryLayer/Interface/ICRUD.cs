using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_House_WPF.RepositoryLayer.Interface
{
    interface ICRUD<T>
    {
        List<T> Get();
        bool Set();
        bool Delete();
        bool Update();

    }
}
