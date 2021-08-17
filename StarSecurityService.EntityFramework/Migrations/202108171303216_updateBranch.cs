namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBranch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branch", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Branch", "Status");
        }
    }
}
