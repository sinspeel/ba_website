using System;
using System.Collections.Generic;

namespace ba_website.model
{
    public class Labels : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Albums> Albums { get; set; }
    }
}
