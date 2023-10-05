using Data.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Data.Concrete
{
    internal class RoleManagement : GenericRepository<Role>, IRoleManagement
    {

        public RoleManagement(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return Context.Set<Role>().ToList();
        }

        public Role GetRoleById(Guid roleId)
        {
            return Context.Set<Role>().Find(roleId);
        }

        public void InsertRole(Role role)
        {
            Context.Set<Role>().Add(role);
            Context.SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            Context.Set<Role>().Update(role);
            Context.SaveChanges();
        }

        public void DeleteRole(Guid roleId)
        {
            var role = GetRoleById(roleId);
            if (role != null)
            {
                Context.Set<Role>().Remove(role);
                Context.SaveChanges();
            }
        }

    }
}
