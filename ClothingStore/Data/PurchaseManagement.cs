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

    public IEnumerable<Purchase> GetAllPurchases()
    {
        return Context.Set<Purchase>().Include(purchase => purchase.Products).ThenInclude(product => product.Product);
    }

    public IEnumerable<Purchase> GetPurchasesByUser(Guid userId)
    {
        return Context.Set<Purchase>().Include(purchase => purchase.Products).ThenInclude(product => product.Product).Where(purchase => purchase.UserId == userId);
    }
}