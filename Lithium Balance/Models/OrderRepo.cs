using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lithium_Balance.Models
{
    public class OrderRepo : Repository<Order>
    {
        public OrderRepo(string path) : base(path)
        {
            
        }
    }
}
