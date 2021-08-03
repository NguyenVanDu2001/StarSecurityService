namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntityPermission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bussiness",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        BusinessId = c.String(maxLength: 128),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bussiness", t => t.BusinessId)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.GroupPermesstion",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        PermisstionId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GroupId, t.PermisstionId })
                .ForeignKey("dbo.GroupUser", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Permission", t => t.PermisstionId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.PermisstionId);
            
            CreateTable(
                "dbo.GroupUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        isAdmin = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GroupUser", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupPermesstion", "PermisstionId", "dbo.Permission");
            DropForeignKey("dbo.User", "GroupId", "dbo.GroupUser");
            DropForeignKey("dbo.GroupPermesstion", "GroupId", "dbo.GroupUser");
            DropForeignKey("dbo.Permission", "BusinessId", "dbo.Bussiness");
            DropIndex("dbo.User", new[] { "GroupId" });
            DropIndex("dbo.GroupPermesstion", new[] { "PermisstionId" });
            DropIndex("dbo.GroupPermesstion", new[] { "GroupId" });
            DropIndex("dbo.Permission", new[] { "BusinessId" });
            DropTable("dbo.User");
            DropTable("dbo.GroupUser");
            DropTable("dbo.GroupPermesstion");
            DropTable("dbo.Permission");
            DropTable("dbo.Bussiness");
        }
    }
}
