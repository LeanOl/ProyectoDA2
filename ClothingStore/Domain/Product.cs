namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public List<string> Colors { get; set; }

        public Product( string name, decimal price, string description, string brand, string category, List<string> colors)
        {
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