

using System;

namespace Domain {

    public class ProductColor {


        public Guid Id { get; set; }
        public string Color { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; } 
    }

    public ProductColor(Guid productId, string color, Product product)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        Color = color;
        Product = product;
    }







}