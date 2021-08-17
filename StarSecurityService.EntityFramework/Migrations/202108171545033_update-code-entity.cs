namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecodeentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeAchievement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        AchievementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Achievement", t => t.AchievementId, cascadeDelete: true)
                .ForeignKey("dbo.Employyee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.AchievementId);
            
            CreateTable(
                "dbo.Employyee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(),
                        Address = c.String(),
                        Image = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Sex = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserName = c.String(),
                        Bonus = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.GroupUser", t => t.GroupId)
                .Index(t => t.BranchId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vacancy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Requirement = c.String(),
                        Title = c.String(),
                        UpdateBy = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        ServiceOfferId = c.Int(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        Salary = c.Single(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Employyee", t => t.UpdateBy, cascadeDelete: true)
                .ForeignKey("dbo.ServiceOffer", t => t.ServiceOfferId, cascadeDelete: true)
                .Index(t => t.UpdateBy)
                .Index(t => t.BranchId)
                .Index(t => t.ServiceOfferId);
            
            CreateTable(
                "dbo.Candidate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        VacancyId = c.Int(nullable: false),
                        Message = c.String(),
                        Email = c.String(),
                        CreateAt = c.DateTime(),
                        UrlFile = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vacancy", t => t.VacancyId, cascadeDelete: true)
                .Index(t => t.VacancyId);
            
            CreateTable(
                "dbo.ServiceOffer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Details = c.String(),
                        Url = c.String(),
                        Introduce = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        ServiceOfferId = c.Int(nullable: false),
                        ShiftStart = c.DateTime(nullable: false),
                        ShiftEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Employyee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceOffer", t => t.ServiceOfferId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ServiceOfferId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Image = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeServiceOffered",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ServiceOfferId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employyee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceOffer", t => t.ServiceOfferId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ServiceOfferId);
            
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
                "dbo.Bussiness",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupPermesstion", "PermisstionId", "dbo.Permission");
            DropForeignKey("dbo.Permission", "BusinessId", "dbo.Bussiness");
            DropForeignKey("dbo.GroupPermesstion", "GroupId", "dbo.GroupUser");
            DropForeignKey("dbo.Employyee", "GroupId", "dbo.GroupUser");
            DropForeignKey("dbo.EmployeeAchievement", "EmployeeId", "dbo.Employyee");
            DropForeignKey("dbo.Employyee", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Vacancy", "ServiceOfferId", "dbo.ServiceOffer");
            DropForeignKey("dbo.EmployeeServiceOffered", "ServiceOfferId", "dbo.ServiceOffer");
            DropForeignKey("dbo.EmployeeServiceOffered", "EmployeeId", "dbo.Employyee");
            DropForeignKey("dbo.ClientEmployees", "ServiceOfferId", "dbo.ServiceOffer");
            DropForeignKey("dbo.ClientEmployees", "EmployeeId", "dbo.Employyee");
            DropForeignKey("dbo.ClientEmployees", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Vacancy", "UpdateBy", "dbo.Employyee");
            DropForeignKey("dbo.Candidate", "VacancyId", "dbo.Vacancy");
            DropForeignKey("dbo.Vacancy", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.EmployeeAchievement", "AchievementId", "dbo.Achievement");
            DropIndex("dbo.Permission", new[] { "BusinessId" });
            DropIndex("dbo.GroupPermesstion", new[] { "PermisstionId" });
            DropIndex("dbo.GroupPermesstion", new[] { "GroupId" });
            DropIndex("dbo.EmployeeServiceOffered", new[] { "ServiceOfferId" });
            DropIndex("dbo.EmployeeServiceOffered", new[] { "EmployeeId" });
            DropIndex("dbo.ClientEmployees", new[] { "ServiceOfferId" });
            DropIndex("dbo.ClientEmployees", new[] { "EmployeeId" });
            DropIndex("dbo.ClientEmployees", new[] { "ClientId" });
            DropIndex("dbo.Candidate", new[] { "VacancyId" });
            DropIndex("dbo.Vacancy", new[] { "ServiceOfferId" });
            DropIndex("dbo.Vacancy", new[] { "BranchId" });
            DropIndex("dbo.Vacancy", new[] { "UpdateBy" });
            DropIndex("dbo.Employyee", new[] { "GroupId" });
            DropIndex("dbo.Employyee", new[] { "BranchId" });
            DropIndex("dbo.EmployeeAchievement", new[] { "AchievementId" });
            DropIndex("dbo.EmployeeAchievement", new[] { "EmployeeId" });
            DropTable("dbo.Bussiness");
            DropTable("dbo.Permission");
            DropTable("dbo.GroupPermesstion");
            DropTable("dbo.GroupUser");
            DropTable("dbo.EmployeeServiceOffered");
            DropTable("dbo.Client");
            DropTable("dbo.ClientEmployees");
            DropTable("dbo.ServiceOffer");
            DropTable("dbo.Candidate");
            DropTable("dbo.Vacancy");
            DropTable("dbo.Branch");
            DropTable("dbo.Employyee");
            DropTable("dbo.EmployeeAchievement");
            DropTable("dbo.Achievement");
        }
    }
}
