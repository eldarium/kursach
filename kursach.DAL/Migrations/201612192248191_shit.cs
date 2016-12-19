namespace kursach.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workers", "AssignedDepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Workers", "AssignedPositionId", "dbo.Staffs");
            DropIndex("dbo.Workers", new[] { "AssignedDepartmentId" });
            DropIndex("dbo.Workers", new[] { "AssignedPositionId" });
            RenameColumn(table: "dbo.Workers", name: "AssignedDepartmentId", newName: "AssignedDepartment_Id");
            RenameColumn(table: "dbo.Workers", name: "AssignedPositionId", newName: "AssignedPosition_Id");
            AlterColumn("dbo.Workers", "AssignedDepartment_Id", c => c.Int());
            AlterColumn("dbo.Workers", "AssignedPosition_Id", c => c.Int());
            CreateIndex("dbo.Workers", "AssignedDepartment_Id");
            CreateIndex("dbo.Workers", "AssignedPosition_Id");
            AddForeignKey("dbo.Workers", "AssignedDepartment_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.Workers", "AssignedPosition_Id", "dbo.Staffs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "AssignedPosition_Id", "dbo.Staffs");
            DropForeignKey("dbo.Workers", "AssignedDepartment_Id", "dbo.Departments");
            DropIndex("dbo.Workers", new[] { "AssignedPosition_Id" });
            DropIndex("dbo.Workers", new[] { "AssignedDepartment_Id" });
            AlterColumn("dbo.Workers", "AssignedPosition_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Workers", "AssignedDepartment_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Workers", name: "AssignedPosition_Id", newName: "AssignedPositionId");
            RenameColumn(table: "dbo.Workers", name: "AssignedDepartment_Id", newName: "AssignedDepartmentId");
            CreateIndex("dbo.Workers", "AssignedPositionId");
            CreateIndex("dbo.Workers", "AssignedDepartmentId");
            AddForeignKey("dbo.Workers", "AssignedPositionId", "dbo.Staffs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Workers", "AssignedDepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
