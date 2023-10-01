namespace Domain
{

    public class ShoppingCart
{
    public List<Product> ProductList { get; set; }
    public Promotion AppliedPromotion { get; set; }

    public ShoppingCart(List<Product> productList, Promotion appliedPromotion)
    {
        ProductList = productList;
        AppliedPromotion = appliedPromotion;
    }


}
}