using Domain;
using Data.Interfaces;
using Logic.Interfaces;
using Exceptions.LogicExceptions;
using APIModels.OutputModels;
using APIModels.InputModels;

namespace Logic.Concrete
{
    public class UserLogic : IUserLogic
    {
        private readonly IGenericRepository<User> _repository;
        public UserLogic(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public UserResponse CreateUser(UserRequest userRequest)
        {
            return new UserResponse (_repository.Insert(userRequest.ToEntity()));
        }

        public IEnumerable<UserResponse> GetAllUsers()
        {
            var users = _repository.GetAll<User>();
            var userResponses = users.Select(user => new UserResponse(user));
            return userResponses;
        }

        public void DeleteUser(Guid id)
        {
            User user = _repository.Get(x => x.Id == id);
            _repository.Delete(user);
        }

        public UserResponse UpdateUser(Guid id, UserRequest updatedUser)
        {
            User user = _repository.Get(x => x.Id == id);
            if(user.Email != null || !"".Equals(updatedUser.Email.Trim()))
            {
                user.Email = updatedUser.Email;
            }
            if (user.DeliveryAddress != null || !"".Equals(updatedUser.DeliveryAddress.Trim()))
            {
                user.DeliveryAddress = updatedUser.DeliveryAddress;
            }
            if (user.Role != null || !"".Equals(updatedUser.Role.Trim()))
            {
                user.Role = updatedUser.Role;
            }
            user.SelfValidations(user.Email, user.Role);
            return new UserResponse(_repository.Update(user));
        }
    }
}
