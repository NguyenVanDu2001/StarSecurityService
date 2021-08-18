namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableHistortyShareHodlder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.History",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        TimeLine = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShareHolder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Address = c.String(),
                        Status = c.Int(nullable: false),
                        JoinCreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShareHolder");
            DropTable("dbo.History");
        }
    }
}
