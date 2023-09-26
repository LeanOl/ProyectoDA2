using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Role
    {

        public Guid RoleId { get; set; } //guid
        public string Name { get; set; }

        public Role(Guid rolId, string name) {
        
            RoleId = Guid.NewGuid();
            Name = name;
        }


    }
}
