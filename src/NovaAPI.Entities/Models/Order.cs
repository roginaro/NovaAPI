using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaAPI.Entities.Models
{
    class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
