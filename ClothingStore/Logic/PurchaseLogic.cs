using APIModels.InputModels;
using Domain;
using Exceptions.LogicExceptions;
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
        List<ShoppingCartProducts>? shoppingCartProducts = shoppingCart.ShoppingCartProducts;
        if (shoppingCartProducts == null || shoppingCartProducts.Count == 0)
        {
            throw new EmptyProductsPurchaseException(LogicExceptionMessages.EmptyCartMessage);
        }
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
        Purchase createdPurchase = _purchaseManagement.AddPurchase(purchase);
        _shoppingCartManagement.ClearShoppingCart(shoppingCart);

        return createdPurchase;
    }

}