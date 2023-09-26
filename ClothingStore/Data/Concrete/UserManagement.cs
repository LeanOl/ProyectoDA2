using System;
using Microsoft.EntityFrameworkCore;
using Domain;

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

