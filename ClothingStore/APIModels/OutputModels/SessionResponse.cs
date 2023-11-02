using Domain;

namespace APIModels.OutputModels;

public class SessionResponse
{
    public Guid Token { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public Guid CartId { get; set; }

    public SessionResponse(Session session)
    {
        Token = session.AuthToken;
        Email = session.User.Email;
        Role = session.User.Role;
        CartId = session.User.ShoppingCart.IdCart;
    }
    
}