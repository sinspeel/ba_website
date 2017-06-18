using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ba_website.model
{
    public class Tracks : BaseEntity
    {
        public int TrackNumber { get; set; }
        public string Title { get; set; }
        public string Length { get; set; }
        public long GenreId { get; set; }
        public long AlbumId { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genres Genres { get; set; }

        [ForeignKey("AlbumId")]
        public virtual Albums Albums { get; set; }
    }
}
