using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRoleManagement
    {

        
            IEnumerable<Role> GetAllRoles();
            Role GetRoleById(Guid roleId);
            void InsertRole(Role role);
            void UpdateRole(Role role);
            void DeleteRole(Guid roleId);
        
       }
}
