using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ShoppingCartProducts
    {
        [Key]
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartProducts()
        {
        }
        public ShoppingCartProducts(Guid shoppingCartId, Guid productId, int quantity)
        {
            ShoppingCartId = Guid.NewGuid();
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
            Quantity = quantity;
        }

    }
}
