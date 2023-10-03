using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ShoppingCartProducts
    {
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartProducts(Guid shoppingCartId, Guid productId, int quantity)
        {
            ShoppingCartId = Guid.NewGuid();
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
            Quantity = quantity;
        }

    }
}
