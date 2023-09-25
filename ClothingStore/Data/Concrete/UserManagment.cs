using System;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Data.Concrete
{
	public class UserManagment : GenericRepository<User>
	{
		public UserManagment(DbContext context)
		{
			Context = context;
		}
	}
}

