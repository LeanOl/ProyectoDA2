using Domain;

namespace Logic.Interfaces
{
    public interface IUserLogic
    {
        User CreateUser(User user);
        IEnumerable<User> GetAllUsers();
        void DeleteUser(Guid id);
        User UpdateUser(Guid id, User isAny);
    }
}
