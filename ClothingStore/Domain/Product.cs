using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public List<String> Colors { get; set; }

        public Product()
        {
        }

        public Product( string name, decimal price, string description, string brand, string category, List<String> colors)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Description = description;
            Brand = brand;
            Category = category;
            Colors = colors;
        }        
    }
}