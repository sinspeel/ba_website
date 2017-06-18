using System;
using System.Collections.Generic;

namespace ba_website.model
{
    public class Musicians : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }
        public string BirthPlace { get; set; }
        public string StageName { get; set; }

        public virtual ICollection<Group_Members> Group_Members { get; set; }

        public virtual ICollection<Events> Events { get; set; }

    }
}
