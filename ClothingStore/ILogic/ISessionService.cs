using Domain;

namespace ILogic
{
    public interface ISessionService
    {
        User? GetCurrentUser(Guid? authToken = null);
        Session Authenticate(string email, string password);
        public void Logout(Guid authToken);
    }
}
