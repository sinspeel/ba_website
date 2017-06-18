using System;
using System.Collections.Generic;

namespace ba_website.model
{
    public class Genres : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Tracks> Tracks { get; set; }
    }
}
