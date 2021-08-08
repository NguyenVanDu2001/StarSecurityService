namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employyee", "GroupId", "dbo.GroupUser");
            DropIndex("dbo.Employyee", new[] { "GroupId" });
            AlterColumn("dbo.Employyee", "GroupId", c => c.Int());
            CreateIndex("dbo.Employyee", "GroupId");
            AddForeignKey("dbo.Employyee", "GroupId", "dbo.GroupUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employyee", "GroupId", "dbo.GroupUser");
            DropIndex("dbo.Employyee", new[] { "GroupId" });
            AlterColumn("dbo.Employyee", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employyee", "GroupId");
            AddForeignKey("dbo.Employyee", "GroupId", "dbo.GroupUser", "Id", cascadeDelete: true);
        }
    }
}
