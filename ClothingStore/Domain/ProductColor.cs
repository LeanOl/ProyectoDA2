using System.ComponentModel.DataAnnotations;

namespace Domain {

    public class ProductColor
    {

        [Key]
        public Guid Id { get; set; }
        public string Color { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public ProductColor()
        {
        }

        public ProductColor(Guid productId, string color, Product product)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Color = color;
            Product = product;
        }



    }

}