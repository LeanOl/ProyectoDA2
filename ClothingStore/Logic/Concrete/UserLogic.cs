using Domain;
using Data.Interfaces;
using Logic.Interfaces;
using Exceptions.LogicExceptions;

namespace Logic.Concrete
{
    public class UserLogic : IUserLogic
    {
        private readonly IGenericRepository<User> _repository;
        public UserLogic(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public User CreateUser(User user)
        {
            return _repository.Insert(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAll<User>();
        }

        public void DeleteUser(Guid id)
        {
            User user = _repository.Get(x => x.Id == id);
            _repository.Delete(user);
        }

        public User UpdateUser(Guid id, User updatedUser)
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
            return _repository.Update(user);
        }
    }
}
