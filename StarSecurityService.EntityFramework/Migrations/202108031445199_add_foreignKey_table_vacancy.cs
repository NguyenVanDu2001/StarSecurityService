namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_foreignKey_table_vacancy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employyee", "BranchId", "dbo.Branch");
            DropIndex("dbo.Employyee", new[] { "BranchId" });
            AlterColumn("dbo.Employyee", "BranchId", c => c.Int());
            CreateIndex("dbo.Employyee", "BranchId");
            CreateIndex("dbo.Vacancy", "EmployeeId");
            CreateIndex("dbo.Vacancy", "BranchId");
            AddForeignKey("dbo.Vacancy", "BranchId", "dbo.Branch", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employyee", "BranchId", "dbo.Branch", "Id");
            AddForeignKey("dbo.Vacancy", "EmployeeId", "dbo.Employyee", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacancy", "EmployeeId", "dbo.Employyee");
            DropForeignKey("dbo.Employyee", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Vacancy", "BranchId", "dbo.Branch");
            DropIndex("dbo.Vacancy", new[] { "BranchId" });
            DropIndex("dbo.Vacancy", new[] { "EmployeeId" });
            DropIndex("dbo.Employyee", new[] { "BranchId" });
            AlterColumn("dbo.Employyee", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employyee", "BranchId");
            AddForeignKey("dbo.Employyee", "BranchId", "dbo.Branch", "Id", cascadeDelete: true);
        }
    }
}
