namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemigrationemployyee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "GroupId", "dbo.GroupUser");
            DropIndex("dbo.User", new[] { "GroupId" });
            AddColumn("dbo.Employyee", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Employyee", "UserName", c => c.String());
            AddColumn("dbo.Employyee", "Bonus", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Employyee", "GroupId", c => c.Int(nullable: true));
            CreateIndex("dbo.Employyee", "GroupId");
            AddForeignKey("dbo.Employyee", "GroupId", "dbo.GroupUser", "Id", cascadeDelete: true);
            DropTable("dbo.User");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PassWord = c.String(),
                        GroupId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Employyee", "GroupId", "dbo.GroupUser");
            DropIndex("dbo.Employyee", new[] { "GroupId" });
            DropColumn("dbo.Employyee", "GroupId");
            DropColumn("dbo.Employyee", "Bonus");
            DropColumn("dbo.Employyee", "UserName");
            DropColumn("dbo.Employyee", "Salary");
            CreateIndex("dbo.User", "GroupId");
            AddForeignKey("dbo.User", "GroupId", "dbo.GroupUser", "Id", cascadeDelete: true);
        }
    }
}
