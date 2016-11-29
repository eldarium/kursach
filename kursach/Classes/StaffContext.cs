using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{
    class StaffContext :DbContext
    {
        public StaffContext() : base("StaffDBConnection") { }

        public DbSet<Staff> Staffs { get; set; }
    }
}
