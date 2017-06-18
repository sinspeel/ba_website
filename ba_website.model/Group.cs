using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ba_website.model
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Group_Members> Group_Members { get; set; }
        public virtual ICollection<Events> Events { get; set; }

    }
}
