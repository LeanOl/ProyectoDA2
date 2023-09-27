using Data.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete;

public class PromotionManagement : GenericRepository<Promotion>
{
    
    public PromotionManagement(DbContext dbContext) 
    {
        Context = dbContext;
    }

    
}