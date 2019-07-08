namespace ManagerPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvhostaccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HostAccounts",
                c => new
                    {
                        HostID = c.Int(nullable: false, identity: true),
                        HostName = c.String(nullable: false, maxLength: 100),
                        HostAddress = c.String(nullable: false, maxLength: 50),
                        HostAccountNum = c.String(nullable: false, maxLength: 50),
                        HostAccountPas = c.String(nullable: false, maxLength: 50),
                        InputDate = c.DateTime(nullable: false),
                        HostNote = c.String(),
                    })
                .PrimaryKey(t => t.HostID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HostAccounts");
        }
    }
}
