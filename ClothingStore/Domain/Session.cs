using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Session")]
    public class Session
    {
        [Key]
        public int Id { get; set; }
        public Guid AuthToken { get; set; }
        public User User { get; set; }

        public Session()
        {
            AuthToken = Guid.NewGuid();
        }
    }
}
