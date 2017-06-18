namespace ba_website.database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventpricenullableadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "NormalPrice", c => c.Double());
            AlterColumn("dbo.Events", "VIPPrice", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "VIPPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Events", "NormalPrice", c => c.Double(nullable: false));
        }
    }
}
