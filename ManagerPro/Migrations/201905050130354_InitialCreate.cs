namespace ManagerPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        AccountNum = c.String(),
                        AccountPassW = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Urllists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WebSiteID = c.Int(nullable: false),
                        WebSiteUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WebLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Website = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WebLists");
            DropTable("dbo.Urllists");
            DropTable("dbo.AccountLists");
        }
    }
}
