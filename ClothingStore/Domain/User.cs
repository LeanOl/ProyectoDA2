namespace Domain;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string DeliveryAddress { get; set; }

    public User(string email, string role, string deliveryAddress)
    {
        Id = Guid.NewGuid();
        Email = email;
        Role = role;
        DeliveryAddress = deliveryAddress;
    }
}