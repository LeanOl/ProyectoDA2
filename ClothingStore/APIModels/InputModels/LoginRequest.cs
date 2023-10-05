using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.InputModels
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "El campo 'Email' no tiene un formato de dirección de correo electrónico válido.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
