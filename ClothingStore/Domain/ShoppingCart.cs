namespace Domain;

public class ShoppingCart
{
    public Guid IdCart { get; set; }
    public Guid IdUsuario { get; set; }
    public List<ShoppingCartProducts> ShoppingCartProducts { get; set; }
    public Promotion AppliedPromotion { get; set; }

    public ShoppingCart(Guid idusuario,List<Product> productList, Promotion appliedPromotion)
    {
        IdCart = Guid.NewGuid();
        IdUsuario = idusuario;
        ShoppingCartProducts = ShoppingCartProducts;
        AppliedPromotion = appliedPromotion;
    }




}