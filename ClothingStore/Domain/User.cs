using Exceptions.LogicExceptions;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }
        [EmailAddress(ErrorMessage = "El campo 'Email' no tiene un formato de dirección de correo electrónico válido.")]
        public string Email { get; set; }
        public string Role { get; set; }
        public string DeliveryAddress { get; set; }

        public User(string email, string role, string deliveryAddress)
        {
            Validations(email);
            Id = Guid.NewGuid();
            Email = email;
            Role = role;
            DeliveryAddress = deliveryAddress;
        }

        private void Validations(string email)
        {
            if (!IsValidEmail(email))
            {
                throw new InvalidFormatEmailException("El campo 'Email' no tiene un formato de dirección de correo electrónico válido.");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}