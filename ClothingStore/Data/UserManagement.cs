using Microsoft.EntityFrameworkCore;
using Domain;
using IData;

namespace Data
{
    public class UserManagement : GenericRepository<User>
    {
        public UserManagement(DbContext context)
        {
            Context = context;
        }
    }
}

