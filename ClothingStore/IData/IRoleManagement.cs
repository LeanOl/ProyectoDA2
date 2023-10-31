using Domain;

namespace IData
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
