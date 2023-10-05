using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete
{
    public class SessionManagement : GenericRepository<Session>
	{
		public SessionManagement(DbContext context)
		{
			Context = context;
		}
	}
}
