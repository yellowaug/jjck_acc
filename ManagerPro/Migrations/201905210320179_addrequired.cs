namespace ManagerPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WebLists", "Website", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.WebLists", "WebsiteUrl", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WebLists", "WebsiteUrl", c => c.String(maxLength: 200));
            AlterColumn("dbo.WebLists", "Website", c => c.String(maxLength: 50));
        }
    }
}
