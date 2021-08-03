namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_foreginkey_vacancy_and_addrequriement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vacancy", "Requirement", c => c.String());
            AddColumn("dbo.Vacancy", "ServiceOfferId", c => c.Int(nullable: false));
            AddColumn("dbo.Candidate", "UrlFile", c => c.String());
            CreateIndex("dbo.Vacancy", "ServiceOfferId");
            AddForeignKey("dbo.Vacancy", "ServiceOfferId", "dbo.ServiceOffer", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacancy", "ServiceOfferId", "dbo.ServiceOffer");
            DropIndex("dbo.Vacancy", new[] { "ServiceOfferId" });
            DropColumn("dbo.Candidate", "UrlFile");
            DropColumn("dbo.Vacancy", "ServiceOfferId");
            DropColumn("dbo.Vacancy", "Requirement");
        }
    }
}
