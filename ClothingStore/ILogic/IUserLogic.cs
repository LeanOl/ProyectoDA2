using APIModels.InputModels;
using APIModels.OutputModels;

namespace ILogic
{
    public interface IUserLogic
    {
        UserResponse CreateUser(UserRequest user);
        IEnumerable<UserResponse> GetAllUsers();
        void DeleteUser(Guid id);
        UserResponse UpdateUser(Guid id, UserRequest isAny);
    }
}
