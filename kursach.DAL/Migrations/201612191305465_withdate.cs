namespace kursach.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class withdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "StartDate");
        }
    }
}
