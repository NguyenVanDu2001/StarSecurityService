namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editfixserviceoffer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceOffer", "Url", c => c.String());
            AddColumn("dbo.ServiceOffer", "Introduce", c => c.String());
            AddColumn("dbo.ServiceOffer", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceOffer", "Description");
            DropColumn("dbo.ServiceOffer", "Introduce");
            DropColumn("dbo.ServiceOffer", "Url");
        }
    }
}
