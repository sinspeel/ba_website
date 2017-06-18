namespace ba_website.database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EventName = c.String(),
                        EventLocation = c.String(),
                        EventStartDate = c.DateTime(nullable: false),
                        EventEndDate = c.DateTime(nullable: false),
                        NormalPrice = c.Double(nullable: false),
                        VIPPrice = c.Double(nullable: false),
                        ArtistId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Events", new[] { "ArtistId" });
            DropTable("dbo.Events");
        }
    }
}
