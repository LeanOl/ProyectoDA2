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
    }
}
