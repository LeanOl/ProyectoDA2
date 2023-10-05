using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; } //guid
        public string Name { get; set; }

        public Role() {}
        public Role(Guid rolId, string name) {
        
            RoleId = Guid.NewGuid();
            Name = name;
        }


    }
}
