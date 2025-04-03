using System.Text.Json.Serialization;

namespace NovaAPI.Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        [JsonIgnore]
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
