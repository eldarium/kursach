namespace kursach.DAL.DataWorkers
{
    public class WorkerContext : DbContext
    {
        public WorkerContext()
            : base("WorkersDBConnection")
        { }

        public DbSet<Worker> Workers { get; set; }
    }
}
