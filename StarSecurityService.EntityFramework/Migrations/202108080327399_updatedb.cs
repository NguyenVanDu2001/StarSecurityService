namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employyee", "Username");
            DropColumn("dbo.Employyee", "Salary");
            DropColumn("dbo.Employyee", "Bonus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employyee", "Bonus", c => c.Single(nullable: false));
            AddColumn("dbo.Employyee", "Salary", c => c.Single(nullable: false));
            AddColumn("dbo.Employyee", "Username", c => c.String());
        }
    }
}
