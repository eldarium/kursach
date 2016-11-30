namespace kursach.DAL.DataWorkers
{
    class StaffContext :DbContext
    {
        public StaffContext() : base("StaffDBConnection") { }

        public DbSet<Staff> Staffs { get; set; }
    }
}
