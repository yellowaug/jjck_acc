namespace ManagerPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcreatetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountLists", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.AccountLists", "Urllist_ID", c => c.Int());
            AddColumn("dbo.AccountLists", "WebList_ID", c => c.Int());
            AlterColumn("dbo.AccountLists", "AccountName", c => c.String(maxLength: 50));
            AlterColumn("dbo.AccountLists", "AccountNum", c => c.String(maxLength: 50));
            AlterColumn("dbo.AccountLists", "AccountPassW", c => c.String(maxLength: 50));
            CreateIndex("dbo.AccountLists", "Urllist_ID");
            CreateIndex("dbo.AccountLists", "WebList_ID");
            AddForeignKey("dbo.AccountLists", "Urllist_ID", "dbo.Urllists", "ID");
            AddForeignKey("dbo.AccountLists", "WebList_ID", "dbo.WebLists", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountLists", "WebList_ID", "dbo.WebLists");
            DropForeignKey("dbo.AccountLists", "Urllist_ID", "dbo.Urllists");
            DropIndex("dbo.AccountLists", new[] { "WebList_ID" });
            DropIndex("dbo.AccountLists", new[] { "Urllist_ID" });
            AlterColumn("dbo.AccountLists", "AccountPassW", c => c.String());
            AlterColumn("dbo.AccountLists", "AccountNum", c => c.String());
            AlterColumn("dbo.AccountLists", "AccountName", c => c.String());
            DropColumn("dbo.AccountLists", "WebList_ID");
            DropColumn("dbo.AccountLists", "Urllist_ID");
            DropColumn("dbo.AccountLists", "CreateTime");
        }
    }
}
