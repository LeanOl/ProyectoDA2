using Domain;
using System.ComponentModel.DataAnnotations;

namespace APIModels.InputModels
{
    public class UserRequest
    {
        [EmailAddress(ErrorMessage = "El campo 'Email' no tiene un formato de dirección de correo electrónico válido.")]
        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string DeliveryAddress { get; set; }

        public UserRequest(string email, string password, string role, string deliveryAddress)
        {
            Email = email;
            Password = password;
            Role = role;
            DeliveryAddress = deliveryAddress;
        }
        public User ToEntity()
        {
            return new User
            (
                Email = Email,
                Password = Password,
                Role = Role,
                DeliveryAddress = DeliveryAddress
            );
        }

    }
}
