using System.Data.Entity;
using kursach.Classes;

namespace kursach.DataWorkers
{
    public class WorkerContext : DbContext
    {
        public WorkerContext()
            : base("WorkersDBConnection")
        { }

        public DbSet<Worker> Workers { get; set; }
    }
}
