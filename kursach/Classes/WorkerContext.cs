using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{
    public class WorkerContext : DbContext
    {
        public WorkerContext()
            : base("WorkerDBConnection")
        { }

        public DbSet<Worker> Workers { get; set; }
    }
}
