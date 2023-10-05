using Microsoft.EntityFrameworkCore;
using Data;

namespace Tests.DataTests
{
    public class ContextInMemory
    {
        protected DbContext createDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ClothingStoreContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
            return new ClothingStoreContext(options);
        }
    }
}
