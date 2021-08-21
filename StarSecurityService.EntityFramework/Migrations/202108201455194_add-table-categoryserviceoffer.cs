namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablecategoryserviceoffer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryServiceOffer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ServiceOffer", "CategoryServiceOfferId", c => c.Int());
            CreateIndex("dbo.ServiceOffer", "CategoryServiceOfferId");
            AddForeignKey("dbo.ServiceOffer", "CategoryServiceOfferId", "dbo.CategoryServiceOffer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceOffer", "CategoryServiceOfferId", "dbo.CategoryServiceOffer");
            DropIndex("dbo.ServiceOffer", new[] { "CategoryServiceOfferId" });
            DropColumn("dbo.ServiceOffer", "CategoryServiceOfferId");
            DropTable("dbo.CategoryServiceOffer");
        }
    }
}
