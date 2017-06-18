using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ba_website.model
{
    public class Group_Members : BaseEntity
    {
        public long MusicianId { get; set; }
        public long GroupId { get; set; }
        public DateTime Joined { get; set; }
        public DateTime Left { get; set; }

        [ForeignKey("MusicianId")]
        public virtual Musicians Musicians { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
    }
}
