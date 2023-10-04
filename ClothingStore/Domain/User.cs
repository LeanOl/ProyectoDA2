using System.ComponentModel.DataAnnotations;

namespace Domain
{

    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public Guid Role { get; set; }
        public string DeliveryAddress { get; set; }

        public User()
        {
        }

    }
}