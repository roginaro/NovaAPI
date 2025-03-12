using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NovaAPI.Entities.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
    }
}
