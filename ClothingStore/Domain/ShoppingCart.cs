using System.ComponentModel.DataAnnotations;

namespace Domain
{

    public class ShoppingCart
    {
        [Key]
        public Guid IdCart { get; set; }
        public Guid UserId { get; set; }
        public List<ShoppingCartProducts> ShoppingCartProducts { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? FinalPrice { get; set; }
        public decimal? Discount { get; set; }
        public string? PromotionName { get; set; }

        public ShoppingCart()
        {
        }

        public ShoppingCart(Guid idusuario, List<ShoppingCartProducts> productList)
        {
            IdCart = Guid.NewGuid();
            UserId = idusuario;
            ShoppingCartProducts = productList;
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