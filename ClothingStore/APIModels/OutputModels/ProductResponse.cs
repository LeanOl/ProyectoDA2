using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIModels.OutputModels
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public List<string> Colors { get; set; }
        public int Stock { get; set; }
        public bool Excluded { get; set; }


        public ProductResponse(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            Description = product.Description;
            Brand = product.Brand;
            Category = product.Category;
            Colors = product.Colors.Select(pc => pc.Color).ToList();
            Stock = product.Stock;
            Excluded = product.Excluded;
        }
    }
}
