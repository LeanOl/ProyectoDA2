using APIModels.InputModels;
using Domain;

namespace ILogic;

public interface IPurchaseLogic
{
    public Purchase CreatePurchase(PurchaseRequest purchaseRequest);
    public IEnumerable<Purchase> GetAllPurchases();
}