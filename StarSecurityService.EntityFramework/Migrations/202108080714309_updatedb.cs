namespace StarSecurityService.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Vacancy", name: "CreateBy", newName: "UpdateBy");
            RenameIndex(table: "dbo.Vacancy", name: "IX_CreateBy", newName: "IX_UpdateBy");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Vacancy", name: "IX_UpdateBy", newName: "IX_CreateBy");
            RenameColumn(table: "dbo.Vacancy", name: "UpdateBy", newName: "CreateBy");
        }
    }
}
