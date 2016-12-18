using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.DAL.Entities;

namespace kursach.DAL.Contexts
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() { }
        public CompanyContext(string connectionString): base(connectionString) {var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyContext, Migrations.Configuration>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
