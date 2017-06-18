using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ba_website.model
{
    public class Events : BaseEntity
    {
        public string EventName { get; set; }
        public string EventLocation { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public double? NormalPrice { get; set; }
        public double? VIPPrice { get; set; }
        public long? MusicianId { get; set; }
        public long? GroupId { get; set; }

        [ForeignKey("MusicianId")]
        public virtual Musicians Musicians { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Groups { get; set; }
    }
}
