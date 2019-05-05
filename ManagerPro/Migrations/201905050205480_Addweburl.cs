namespace ManagerPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addweburl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WebLists", "WebsiteUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WebLists", "WebsiteUrl");
        }
    }
}
