using Domain;
using IData;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class PurchaseManagement : GenericRepository<Purchase> , IPurchaseManagement
{
    public PurchaseManagement(DbContext context)
    {

        Context = context;
    }
    public Purchase AddPurchase(Purchase purchase)
    {
        Context.Set<Purchase>().Add(purchase);
        Context.SaveChanges();
        return purchase;
    }
}