using System.Collections.Generic;

namespace kursach.DAL.Entities
{
    public class Staff : CompanyEntity
    {
        private ISet<Worker> AssignedWorkers;
        public int StaffId { get; private set; }
        public string Name { get; private set; }

        private Staff()
        {
        }
    }
}