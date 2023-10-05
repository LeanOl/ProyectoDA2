using Domain;
using System.ComponentModel.DataAnnotations;

namespace APIModels.InputModels
{
    
    public class ProductRequest
    {
        [Required(ErrorMessage = "El campo 'Name' es requerido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo 'Price' es requerido.")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        [Required(ErrorMessage = "El campo 'Category' es requerido.")]
        public string Category { get; set; }

        public List<string> Colors { get; set; }

        public Product ToEntity()
        {
            return new Product
            {
                Name = Name,
                Price = Price,
                Description = Description,
                Brand = Brand,
                Category = Category,
                Colors = Colors
            };
        }
    }
}
