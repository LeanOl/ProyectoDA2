namespace Domain;

public class User
{
    public string Email { get; set; }
    public string Role { get; set; }
    public string DeliveryAddress { get; set; }

    public User(string email, string role, string deliveryAddress)
    {
        Email = email;
        Role = role;
        DeliveryAddress = deliveryAddress;
    }
}