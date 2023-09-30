namespace Domain;

public class ShoppingCart
{
    public Guid IdUsuario { get; set; }
    public List<Product> ProductList { get; set; }
    public Promotion AppliedPromotion { get; set; }//necesita promotion ?

    public ShoppingCart(Guid idusuario,List<Product> productList, Promotion appliedPromotion)
    {
        IdUsuario = idusuario;
        ProductList = productList;
        AppliedPromotion = appliedPromotion;
    }


}