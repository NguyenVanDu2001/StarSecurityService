namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addurlachievement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Achievement", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Achievement", "Url");
        }
    }
}
