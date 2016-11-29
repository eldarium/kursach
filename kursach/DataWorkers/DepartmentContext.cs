using System.Data.Entity;
using kursach.Classes;

namespace kursach.DataWorkers
{
    class DepartmentContext : DbContext
    {
        public DepartmentContext() : base("DepartmentsDBConnection") { }

        public DbSet<Department> Departments { get; set; }
    }
}
