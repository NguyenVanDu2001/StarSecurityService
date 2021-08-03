namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_entity_System_relationship : DbMigration
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
                "dbo.ServiceOffer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Details = c.String(),
                        Status = c.Boolean(nullable: false),
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
                "dbo.Branch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        StartDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vacancy", t => t.VacancyId, cascadeDelete: true)
                .Index(t => t.VacancyId);
            
            CreateTable(
                "dbo.Vacancy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employyee", "BranchId", c => c.Int(nullable: true));
            AddColumn("dbo.Employyee", "Address", c => c.String());
            AddColumn("dbo.Employyee", "Image", c => c.String());
            AddColumn("dbo.Employyee", "Password", c => c.String());
            AddColumn("dbo.Employyee", "Email", c => c.String());
            AddColumn("dbo.Employyee", "Phone", c => c.String());
            AddColumn("dbo.Employyee", "Sex", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employyee", "Status", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Employyee", "BranchId");
            AddForeignKey("dbo.Employyee", "BranchId", "dbo.Branch", "Id", cascadeDelete: true);
            DropColumn("dbo.Employyee", "Code");
            DropColumn("dbo.Employyee", "Name");
            DropColumn("dbo.Employyee", "Adress");
            DropColumn("dbo.Employyee", "ContactNumber");
            DropColumn("dbo.Employyee", "Role");
            DropColumn("dbo.Employyee", "Grade");
            DropColumn("dbo.Employyee", "Client");
            DropColumn("dbo.Employyee", "Achievements");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employyee", "Achievements", c => c.Int());
            AddColumn("dbo.Employyee", "Client", c => c.Int(nullable: false));
            AddColumn("dbo.Employyee", "Grade", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employyee", "Role", c => c.Int());
            AddColumn("dbo.Employyee", "ContactNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Employyee", "Adress", c => c.String());
            AddColumn("dbo.Employyee", "Name", c => c.String());
            AddColumn("dbo.Employyee", "Code", c => c.String());
            DropForeignKey("dbo.Candidate", "VacancyId", "dbo.Vacancy");
            DropForeignKey("dbo.Employyee", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.EmployeeAchievement", "EmployeeId", "dbo.Employyee");
            DropForeignKey("dbo.EmployeeServiceOffered", "ServiceOfferId", "dbo.ServiceOffer");
            DropForeignKey("dbo.EmployeeServiceOffered", "EmployeeId", "dbo.Employyee");
            DropForeignKey("dbo.ClientEmployees", "ServiceOfferId", "dbo.ServiceOffer");
            DropForeignKey("dbo.ClientEmployees", "EmployeeId", "dbo.Employyee");
            DropForeignKey("dbo.ClientEmployees", "ClientId", "dbo.Client");
            DropForeignKey("dbo.EmployeeAchievement", "AchievementId", "dbo.Achievement");
            DropIndex("dbo.Candidate", new[] { "VacancyId" });
            DropIndex("dbo.EmployeeServiceOffered", new[] { "ServiceOfferId" });
            DropIndex("dbo.EmployeeServiceOffered", new[] { "EmployeeId" });
            DropIndex("dbo.ClientEmployees", new[] { "ServiceOfferId" });
            DropIndex("dbo.ClientEmployees", new[] { "EmployeeId" });
            DropIndex("dbo.ClientEmployees", new[] { "ClientId" });
            DropIndex("dbo.Employyee", new[] { "BranchId" });
            DropIndex("dbo.EmployeeAchievement", new[] { "AchievementId" });
            DropIndex("dbo.EmployeeAchievement", new[] { "EmployeeId" });
            DropColumn("dbo.Employyee", "Status");
            DropColumn("dbo.Employyee", "Sex");
            DropColumn("dbo.Employyee", "Phone");
            DropColumn("dbo.Employyee", "Email");
            DropColumn("dbo.Employyee", "Password");
            DropColumn("dbo.Employyee", "Image");
            DropColumn("dbo.Employyee", "Address");
            DropColumn("dbo.Employyee", "BranchId");
            DropTable("dbo.Vacancy");
            DropTable("dbo.Candidate");
            DropTable("dbo.Branch");
            DropTable("dbo.EmployeeServiceOffered");
            DropTable("dbo.ServiceOffer");
            DropTable("dbo.Client");
            DropTable("dbo.ClientEmployees");
            DropTable("dbo.EmployeeAchievement");
            DropTable("dbo.Achievement");
        }
    }
}
