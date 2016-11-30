namespace kursach.DAL.DataWorkers
{
    public class DepartmentContext : DbContext
    {
        public DepartmentContext() : base("DepartmentsDBConnection") { }

        public DbSet<Department> Departments { get; set; }
    }
}
