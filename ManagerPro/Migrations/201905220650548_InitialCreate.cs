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
                        AccountName = c.String(nullable: false, maxLength: 50),
                        AccountNum = c.String(nullable: false, maxLength: 50),
                        AccountPassW = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        Note = c.String(),
                        Urllist_ID = c.Int(),
                        WebList_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Urllists", t => t.Urllist_ID)
                .ForeignKey("dbo.WebLists", t => t.WebList_ID)
                .Index(t => t.Urllist_ID)
                .Index(t => t.WebList_ID);
            
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
                        Website = c.String(nullable: false, maxLength: 50),
                        WebsiteUrl = c.String(nullable: false, maxLength: 200),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountLists", "WebList_ID", "dbo.WebLists");
            DropForeignKey("dbo.AccountLists", "Urllist_ID", "dbo.Urllists");
            DropIndex("dbo.AccountLists", new[] { "WebList_ID" });
            DropIndex("dbo.AccountLists", new[] { "Urllist_ID" });
            DropTable("dbo.WebLists");
            DropTable("dbo.Urllists");
            DropTable("dbo.AccountLists");
        }
    }
}
