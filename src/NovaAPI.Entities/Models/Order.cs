using System.Text.Json.Serialization;

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
        public ICollection<OrderProduct> OrderProducts { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }
    }
}
