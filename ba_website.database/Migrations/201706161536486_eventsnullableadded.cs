namespace ba_website.database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventsnullableadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "MusicianId", "dbo.Musicians");
            DropIndex("dbo.Events", new[] { "MusicianId" });
            AddColumn("dbo.Events", "GroupId", c => c.Long());
            AlterColumn("dbo.Events", "MusicianId", c => c.Long());
            CreateIndex("dbo.Events", "MusicianId");
            CreateIndex("dbo.Events", "GroupId");
            AddForeignKey("dbo.Events", "GroupId", "dbo.Groups", "Id");
            AddForeignKey("dbo.Events", "MusicianId", "dbo.Musicians", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "MusicianId", "dbo.Musicians");
            DropForeignKey("dbo.Events", "GroupId", "dbo.Groups");
            DropIndex("dbo.Events", new[] { "GroupId" });
            DropIndex("dbo.Events", new[] { "MusicianId" });
            AlterColumn("dbo.Events", "MusicianId", c => c.Long(nullable: false));
            DropColumn("dbo.Events", "GroupId");
            CreateIndex("dbo.Events", "MusicianId");
            AddForeignKey("dbo.Events", "MusicianId", "dbo.Musicians", "Id", cascadeDelete: true);
        }
    }
}
