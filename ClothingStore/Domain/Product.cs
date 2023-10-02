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
        public List<ProductColor> Colors { get; set; }

        public Product(/*int id,*/ string name, decimal price, string description, string brand, string category, List<ProductColor> colors)
        {
            Id = Guid.NewGuid();//capaz el guid se va del constructor
            Name = name;
            Price = price;
            Description = description;
            Brand = brand;
            Category = category;
            Colors = colors;
        }

    }
}