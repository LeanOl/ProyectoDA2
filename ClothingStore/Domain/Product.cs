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
        public List<ProductColor> Colors { get; set; }

        public Product()
        {
        }

        public Product( string name, decimal price, string description, string brand, string category, List<string> colors)
        {
            Id = Guid.NewGuid();//capaz el guid se va del constructor
            Name = name;
            Price = price;
            Description = description;
            Brand = brand;
            Category = category;
            Colors = colors;
        }

        public Product()
        {
        }

        

    }
}