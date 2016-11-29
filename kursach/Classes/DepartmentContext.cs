using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{
    class DepartmentContext : DbContext
    {
        public DepartmentContext() : base("DepartmentsDBConnection") { }

        public DbSet<Department> Departments { get; set; }
    }
}
