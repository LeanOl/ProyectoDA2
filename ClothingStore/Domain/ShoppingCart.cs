using System.ComponentModel.DataAnnotations;

namespace Domain
{

    public class ShoppingCart
    {
        [Key]
        public Guid IdCart { get; set; }
        public Guid IdUsuario { get; set; }
        public List<ShoppingCartProducts> ShoppingCartProducts { get; set; }
        public Promotion AppliedPromotion { get; set; }

        public ShoppingCart()
        {
        }

        public ShoppingCart(Guid idusuario, List<ShoppingCartProducts> productList, Promotion appliedPromotion)
        {
            IdCart = Guid.NewGuid();
            IdUsuario = idusuario;
            ShoppingCartProducts = productList;
            AppliedPromotion = appliedPromotion;
        }

        public List<Product> GetProducts ()
        {
            if (ShoppingCartProducts == null || ShoppingCartProducts.Count == 0)
            {
                return new List<Product>();
            }
            var products = ShoppingCartProducts.Select(sp => sp.Product).ToList();
            return products;
        }
    }
}