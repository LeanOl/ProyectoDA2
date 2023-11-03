using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ShoppingCartProducts
    {
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartProducts()
        {
        }
        public ShoppingCartProducts(Guid shoppingCartId, Product product, int quantity)
        {
            ShoppingCartId = shoppingCartId;
            Product = product;
            ProductId = product.Id;
            Quantity = quantity;
        }

    }
}
