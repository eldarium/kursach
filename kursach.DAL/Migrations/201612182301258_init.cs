namespace kursach.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        BankAccount = c.Long(nullable: false),
                        AssignedDepartment_Id = c.Int(),
                        AssignedPosition_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.AssignedDepartment_Id)
                .ForeignKey("dbo.Staffs", t => t.AssignedPosition_Id)
                .Index(t => t.AssignedDepartment_Id)
                .Index(t => t.AssignedPosition_Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Salary = c.Double(nullable: false),
                        WorkTime = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectWorkers",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        Worker_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.Worker_Id })
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.Worker_Id, cascadeDelete: true)
                .Index(t => t.Project_Id)
                .Index(t => t.Worker_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectWorkers", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.ProjectWorkers", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Workers", "AssignedPosition_Id", "dbo.Staffs");
            DropForeignKey("dbo.Workers", "AssignedDepartment_Id", "dbo.Departments");
            DropIndex("dbo.ProjectWorkers", new[] { "Worker_Id" });
            DropIndex("dbo.ProjectWorkers", new[] { "Project_Id" });
            DropIndex("dbo.Workers", new[] { "AssignedPosition_Id" });
            DropIndex("dbo.Workers", new[] { "AssignedDepartment_Id" });
            DropTable("dbo.ProjectWorkers");
            DropTable("dbo.Projects");
            DropTable("dbo.Staffs");
            DropTable("dbo.Workers");
            DropTable("dbo.Departments");
        }
    }
}
