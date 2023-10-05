using Domain;
using System.ComponentModel.DataAnnotations;

namespace APIModels.InputModels
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "El campo 'Email' es requerido.")]
        [EmailAddress(ErrorMessage = "El campo 'Email' no tiene un formato de dirección de correo electrónico válido.")]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required(ErrorMessage = "El campo 'Role' es requerido.")]
        public string Role { get; set; }

        [Required(ErrorMessage = "El campo 'DeliveryAddress' es requerido.")]
        public string DeliveryAddress { get; set; }

        public CreateUserRequest(string email, string password, string role, string deliveryAddress)
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

        public UserRequest ToUserRequest()
        {
            return new UserRequest
            (
                Email = Email,
                Password = Password,
                Role = Role,
                DeliveryAddress = DeliveryAddress
            );
        }
    }
}
