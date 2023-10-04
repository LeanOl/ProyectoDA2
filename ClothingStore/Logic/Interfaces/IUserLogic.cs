using Domain;
using APIModels.OutputModels;
using APIModels.InputModels;

namespace Logic.Interfaces
{
    public interface IUserLogic
    {
        UserResponse CreateUser(UserRequest user);
        IEnumerable<UserResponse> GetAllUsers();
        void DeleteUser(Guid id);
        UserResponse UpdateUser(Guid id, UserRequest isAny);
    }
}
