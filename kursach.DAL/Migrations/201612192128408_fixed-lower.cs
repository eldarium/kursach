namespace kursach.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedlower : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workers", "AssignedDepartment_Id", "dbo.Departments");
            DropForeignKey("dbo.Workers", "AssignedPosition_Id", "dbo.Staffs");
            DropIndex("dbo.Workers", new[] { "AssignedDepartment_Id" });
            DropIndex("dbo.Workers", new[] { "AssignedPosition_Id" });
            RenameColumn(table: "dbo.Workers", name: "AssignedDepartment_Id", newName: "AssignedDepartmentId");
            RenameColumn(table: "dbo.Workers", name: "AssignedPosition_Id", newName: "AssignedPositionId");
            AlterColumn("dbo.Workers", "AssignedDepartmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Workers", "AssignedPositionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Workers", "AssignedDepartmentId");
            CreateIndex("dbo.Workers", "AssignedPositionId");
            AddForeignKey("dbo.Workers", "AssignedDepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Workers", "AssignedPositionId", "dbo.Staffs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "AssignedPositionId", "dbo.Staffs");
            DropForeignKey("dbo.Workers", "AssignedDepartmentId", "dbo.Departments");
            DropIndex("dbo.Workers", new[] { "AssignedPositionId" });
            DropIndex("dbo.Workers", new[] { "AssignedDepartmentId" });
            AlterColumn("dbo.Workers", "AssignedPositionId", c => c.Int());
            AlterColumn("dbo.Workers", "AssignedDepartmentId", c => c.Int());
            RenameColumn(table: "dbo.Workers", name: "AssignedPositionId", newName: "AssignedPosition_Id");
            RenameColumn(table: "dbo.Workers", name: "AssignedDepartmentId", newName: "AssignedDepartment_Id");
            CreateIndex("dbo.Workers", "AssignedPosition_Id");
            CreateIndex("dbo.Workers", "AssignedDepartment_Id");
            AddForeignKey("dbo.Workers", "AssignedPosition_Id", "dbo.Staffs", "Id");
            AddForeignKey("dbo.Workers", "AssignedDepartment_Id", "dbo.Departments", "Id");
        }
    }
}
