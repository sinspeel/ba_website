namespace ba_website.database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.DateTime(nullable: false),
                        ArtistId = c.Long(nullable: false),
                        LabelId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Labels", t => t.LabelId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.LabelId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Group_Members",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MusicianId = c.Long(nullable: false),
                        ArtistId = c.Long(nullable: false),
                        Joined = c.DateTime(nullable: false),
                        Left = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Musicians", t => t.MusicianId, cascadeDelete: true)
                .Index(t => t.MusicianId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Musicians",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        BirthPlace = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Labels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TrackNumber = c.Int(nullable: false),
                        Title = c.String(),
                        Length = c.String(),
                        GenreId = c.Long(nullable: false),
                        AlbumId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.AlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "LabelId", "dbo.Labels");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Group_Members", "MusicianId", "dbo.Musicians");
            DropForeignKey("dbo.Group_Members", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Tracks", new[] { "AlbumId" });
            DropIndex("dbo.Tracks", new[] { "GenreId" });
            DropIndex("dbo.Group_Members", new[] { "ArtistId" });
            DropIndex("dbo.Group_Members", new[] { "MusicianId" });
            DropIndex("dbo.Albums", new[] { "LabelId" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropTable("dbo.Tracks");
            DropTable("dbo.Genres");
            DropTable("dbo.Labels");
            DropTable("dbo.Musicians");
            DropTable("dbo.Group_Members");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
