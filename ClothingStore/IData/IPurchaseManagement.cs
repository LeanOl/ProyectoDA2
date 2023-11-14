using Domain;

namespace IData;

public interface IPurchaseManagement 
{
    Purchase AddPurchase(Purchase purchase);
    IEnumerable<Purchase> GetAllPurchases();
    IEnumerable<Purchase> GetPurchasesByUser(Guid userId);
}