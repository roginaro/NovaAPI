using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NovaAPI.Entities.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public int CustomerId { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; }

        [JsonIgnore]
        public ICollection<Customer> Customers { get; set; }
    }
}
