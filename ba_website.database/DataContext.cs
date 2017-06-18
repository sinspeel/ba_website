using System;
using System.Collections.Generic;
using System.Data.Entity;
using ba_website.model;

namespace ba_website.database
{
    public class DataContext : DbContext
    {
        public DbSet<Albums> Albums { get; set; }
        public DbSet<Tracks> Tracks { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Labels> Labels { get; set; }
        public DbSet<Musicians> Musicians { get; set; }
        public DbSet<Group_Members> Group_Members { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Group> Group { get; set; }

        public DataContext()
            : base("name=ba_database") { }


    }
}
