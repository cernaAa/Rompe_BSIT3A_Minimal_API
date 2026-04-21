using System.Text.Json.Serialization;

namespace ProductAPIDemo.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Relationship: One Category has many Products
        [JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}