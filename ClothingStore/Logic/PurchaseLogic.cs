using APIModels.InputModels;
using Domain;
using IData;
using ILogic;

namespace Logic;

public class PurchaseLogic : IPurchaseLogic
{
    IShoppingCartManagement _shoppingCartManagement;
    IPurchaseManagement _purchaseManagement;
    public PurchaseLogic(IPurchaseManagement purchaseManagement, IShoppingCartManagement shoppingCartManagement)
    {
        _purchaseManagement = purchaseManagement;
        _shoppingCartManagement = shoppingCartManagement;
    }
    public Purchase CreatePurchase(PurchaseRequest purchaseRequest)
    {
        Guid userId = purchaseRequest.UserId;
        ShoppingCart shoppingCart = _shoppingCartManagement.GetShoppingCartByUserId(userId);
        List<ShoppingCartProducts> shoppingCartProducts = shoppingCart.ShoppingCartProducts;
        List<PurchaseProduct> purchaseProducts = shoppingCartProducts.ConvertAll(product =>
                       new PurchaseProduct{ProductId = product.ProductId,Product = product.Product,Quantity = product.Quantity});
        Purchase purchase = new Purchase
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Products = purchaseProducts,
            TotalPrice = shoppingCart.TotalPrice,
            FinalPrice = shoppingCart.FinalPrice,
            Discount = shoppingCart.Discount,
            PromotionName = shoppingCart.PromotionName,
            Date = DateTime.Now,
            PaymentMethod = purchaseRequest.PaymentMethod
        };

        return _purchaseManagement.AddPurchase(purchase);
    }

}