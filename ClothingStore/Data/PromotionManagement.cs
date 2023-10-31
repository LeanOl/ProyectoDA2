using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PromotionManagement : GenericRepository<Promotion>
    {

        public PromotionManagement(DbContext dbContext)
        {
            Context = dbContext;
        }

        public override void Delete(Promotion entity)
        {
            if (entity.PromotionConditions != null)
            {
                foreach (var condition in entity.PromotionConditions.ToList())
                {
                    entity.PromotionConditions.Remove(condition);
                }
            }
            Context.Set<Promotion>().Remove(entity);
            Save();
        }

    }
}