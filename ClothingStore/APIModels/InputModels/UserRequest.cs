using Domain;
using System.ComponentModel.DataAnnotations;

namespace APIModels.InputModels
{
    public class UserRequest
    {
        [Required(ErrorMessage = "El campo 'Email' es requerido.")]
        [EmailAddress(ErrorMessage = "El campo 'Email' no tiene un formato de dirección de correo electrónico válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo 'Role' es requerido.")]
        public string Role { get; set; }

        [Required(ErrorMessage = "El campo 'DeliveryAddress' es requerido.")]
        public string DeliveryAddress { get; set; }

        public UserRequest(string email, string role, string deliveryAddress)
        {
            Email = email;
            Role = role;
            DeliveryAddress = deliveryAddress;
        }
        public User ToEntity()
        {
            return new User
            (
                Email = Email,
                Role = Role,
                DeliveryAddress = DeliveryAddress
            );
        }

    }
}
