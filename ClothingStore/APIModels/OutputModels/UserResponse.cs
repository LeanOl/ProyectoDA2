using Domain;

namespace APIModels.OutputModels
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string DeliveryAddress { get; set; }

        public UserResponse(User user)
        {
            Id = user.Id;
            Email = user.Email;
            Role = user.Role;
            DeliveryAddress = user.DeliveryAddress;
        }
    }
}
