namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidate", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Candidate", "CreateAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidate", "CreateAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.Candidate", "StartDate");
        }
    }
}