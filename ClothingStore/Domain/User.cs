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
            SelfValidations(email,role);
            Id = Guid.NewGuid();
            Email = email;
            Role = role;
            DeliveryAddress = deliveryAddress;
        }

        public void SelfValidations(string email, string role)
        {
            if (!IsValidRol(role))
            {
                throw new InvalidRolException("El campo 'Rol' no es valido, debe ser ADMIN o USER.");
            }

            if (!IsValidEmail(email))
            {
                throw new InvalidFormatEmailException("El campo 'Email' no tiene un formato de dirección de correo electrónico válido.");
            }
        }

        private bool IsValidRol(string role)
        {
            if (role == null || "".Equals(role.Trim())) return false;
            return ("ADMIN".Equals(role.ToUpper()) || "USER".Equals(role.ToUpper()));
        }

        private bool IsValidEmail(string email)
        {
            if (email == null) return false;
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