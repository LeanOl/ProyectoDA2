using Domain;

namespace Logic.Interfaces
{
    public interface ISessionService
    {
        User? GetCurrentUser(Guid? authToken = null);
        Guid Authenticate(string email, string password);
        public void Logout(Guid authToken);
    }
}
