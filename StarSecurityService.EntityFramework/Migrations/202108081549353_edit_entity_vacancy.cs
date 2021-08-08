namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_entity_vacancy : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Vacancy", name: "EmployeeId", newName: "UpdateBy");
            RenameIndex(table: "dbo.Vacancy", name: "IX_EmployeeId", newName: "IX_UpdateBy");
            AddColumn("dbo.Vacancy", "Title", c => c.String());
            AddColumn("dbo.Vacancy", "UpdateAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vacancy", "Salary", c => c.Single(nullable: false));
            DropColumn("dbo.Vacancy", "Description");
            DropColumn("dbo.Vacancy", "EndDate");
            DropColumn("dbo.Vacancy", "StartDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vacancy", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vacancy", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vacancy", "Description", c => c.String());
            DropColumn("dbo.Vacancy", "Salary");
            DropColumn("dbo.Vacancy", "UpdateAt");
            DropColumn("dbo.Vacancy", "Title");
            RenameIndex(table: "dbo.Vacancy", name: "IX_UpdateBy", newName: "IX_EmployeeId");
            RenameColumn(table: "dbo.Vacancy", name: "UpdateBy", newName: "EmployeeId");
        }
    }
}
