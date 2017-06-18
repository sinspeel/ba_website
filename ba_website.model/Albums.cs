using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ba_website.model
{
    public class Albums : BaseEntity
    {
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public long MusicianId { get; set; }
        public long LabelId { get; set; }

        [ForeignKey("MusicianId")]
        public virtual Musicians Musicians { get; set; }
        [ForeignKey("LabelId")]
        public virtual Labels Labels { get; set; }
    }
}
