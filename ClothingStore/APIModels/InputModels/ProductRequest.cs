using Domain;
using System.ComponentModel.DataAnnotations;

namespace APIModels.InputModels
{
    
    public class ProductRequest
    {
        public Guid? Id { get; set; }
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
           {
               Id = Guid.Empty,
               Name = Name,
               Price = Price,
               Description = Description,
               Brand = Brand,
               Category = Category,
               Stock = Stock,
               Excluded = Excluded
           };
            productToReturn.Colors = Colors.ConvertAll(color => new ProductColor(productToReturn.Id, color, productToReturn));
            return productToReturn;
        }

        public Product ToEntity(Guid? id)
        {
            Product productToReturn = new Product
            {
                Id = id ?? Guid.Empty,
                Name = Name,
                Price = Price,
                Description = Description,
                Brand = Brand,
                Category = Category,
                Stock = Stock,
                Excluded = Excluded
            };
            productToReturn.Colors = Colors.ConvertAll(color => new ProductColor(productToReturn.Id, color, productToReturn));
            return productToReturn;
        }
    }
}
