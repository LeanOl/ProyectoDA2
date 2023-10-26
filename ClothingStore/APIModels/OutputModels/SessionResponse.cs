using Domain;

namespace APIModels.OutputModels;

public class SessionResponse
{
    public Guid Token { get; set; }
    public bool Ok { get; set;}
    public string Email { get; set; }
    public string Role { get; set; }

    public SessionResponse(Session session)
    {
        Token = session.AuthToken;
        Ok = true;
        Email = session.User.Email;
        Role = session.User.Role;
    }
    
}