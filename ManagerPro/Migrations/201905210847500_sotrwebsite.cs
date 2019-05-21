namespace ManagerPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sotrwebsite : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccountLists", "AccountName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AccountLists", "AccountNum", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AccountLists", "AccountPassW", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AccountLists", "AccountPassW", c => c.String(maxLength: 50));
            AlterColumn("dbo.AccountLists", "AccountNum", c => c.String(maxLength: 50));
            AlterColumn("dbo.AccountLists", "AccountName", c => c.String(maxLength: 50));
        }
    }
}
