using System.Text.Json.Serialization;

namespace ProductAPIDemo.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;

        // Relationship: One Supplier has many Products
        [JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}