using System.Data.Entity;
using kursach.Classes;

namespace kursach.DataWorkers
{
    class StaffContext :DbContext
    {
        public StaffContext() : base("StaffDBConnection") { }

        public DbSet<Staff> Staffs { get; set; }
    }
}
