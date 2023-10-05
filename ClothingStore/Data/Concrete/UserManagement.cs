using Microsoft.EntityFrameworkCore;
using Domain;
using Data.Interfaces;

namespace Data.Concrete
{
	public class UserManagement : GenericRepository<User>
	{
		public UserManagement(DbContext context)
		{
			Context = context;
		}
    }
}

