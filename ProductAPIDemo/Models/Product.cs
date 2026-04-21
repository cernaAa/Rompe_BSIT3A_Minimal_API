using System.ComponentModel.DataAnnotations;

namespace ProductAPIDemo.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Range(1, 1000000)]
        public decimal Price { get; set; }

        [Range(0, 1000000)]
        public int Stock { get; set; }

        // Foreign Key to connect to Category
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // Foreign Key to connect to Supplier
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }
}