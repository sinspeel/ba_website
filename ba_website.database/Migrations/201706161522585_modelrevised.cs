namespace ba_website.database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelrevised : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Group_Members", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Events", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropIndex("dbo.Group_Members", new[] { "ArtistId" });
            DropIndex("dbo.Events", new[] { "ArtistId" });
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        GroupName = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Albums", "MusicianId", c => c.Long(nullable: false));
            AddColumn("dbo.Group_Members", "GroupId", c => c.Long(nullable: false));
            AddColumn("dbo.Musicians", "StageName", c => c.String());
            AddColumn("dbo.Events", "MusicianId", c => c.Long(nullable: false));
            CreateIndex("dbo.Albums", "MusicianId");
            CreateIndex("dbo.Events", "MusicianId");
            CreateIndex("dbo.Group_Members", "GroupId");
            AddForeignKey("dbo.Events", "MusicianId", "dbo.Musicians", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Group_Members", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Albums", "MusicianId", "dbo.Musicians", "Id", cascadeDelete: true);
            DropColumn("dbo.Albums", "ArtistId");
            DropColumn("dbo.Group_Members", "ArtistId");
            DropColumn("dbo.Events", "ArtistId");
            DropTable("dbo.Artists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Events", "ArtistId", c => c.Long(nullable: false));
            AddColumn("dbo.Group_Members", "ArtistId", c => c.Long(nullable: false));
            AddColumn("dbo.Albums", "ArtistId", c => c.Long(nullable: false));
            DropForeignKey("dbo.Albums", "MusicianId", "dbo.Musicians");
            DropForeignKey("dbo.Group_Members", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Events", "MusicianId", "dbo.Musicians");
            DropIndex("dbo.Group_Members", new[] { "GroupId" });
            DropIndex("dbo.Events", new[] { "MusicianId" });
            DropIndex("dbo.Albums", new[] { "MusicianId" });
            DropColumn("dbo.Events", "MusicianId");
            DropColumn("dbo.Musicians", "StageName");
            DropColumn("dbo.Group_Members", "GroupId");
            DropColumn("dbo.Albums", "MusicianId");
            DropTable("dbo.Groups");
            CreateIndex("dbo.Events", "ArtistId");
            CreateIndex("dbo.Group_Members", "ArtistId");
            CreateIndex("dbo.Albums", "ArtistId");
            AddForeignKey("dbo.Events", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Albums", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Group_Members", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
        }
    }
}
