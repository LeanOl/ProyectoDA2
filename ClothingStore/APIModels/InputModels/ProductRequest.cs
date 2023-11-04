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

        [Required(ErrorMessage = "El campo 'Stock' es requerido.")]
        public int Stock { get; set; }
        
        [Required(ErrorMessage = "El campo 'Exluido' es requerido.")]
        public bool Excluded { get; set; }



        public Product ToEntity()
        {
           Product productToReturn = new Product
           (
               Name,
                Price,
                Description,
                Brand,
                Category,
                null,  
                Stock,
                Excluded
           );
            productToReturn.Colors = Colors.ConvertAll(color => new ProductColor(productToReturn.Id, color, productToReturn));
            return productToReturn;
        }
    }
}
