namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntityEmployees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employyee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Adress = c.String(),
                        ContactNumber = c.Int(nullable: false),
                        Role = c.Int(),
                        Grade = c.Boolean(nullable: false),
                        Client = c.Int(nullable: false),
                        Achievements = c.Int(),
                        BirthDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employyee");
        }
    }
}
