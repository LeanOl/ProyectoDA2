﻿using Domain;

namespace APIModels.OutputModels;

public class SessionResponse
{
    public Guid Token { get; set; }
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public ShoppingCartResponse Cart { get; set; }

    public SessionResponse(Session session)
    {
        Token = session.AuthToken;
        Email = session.User.Email;
        UserId = session.User.Id;
        Role = session.User.Role;
        Cart = new ShoppingCartResponse(session.User.ShoppingCart);
    }
    
}