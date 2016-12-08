using System.Collections.Generic;

namespace kursach.DAL.Entities
{
    public class Staff : CompanyEntity
    {
        private ISet<Worker> AssignedWorkers;
        public int StaffId { get;  set; }
        public string Name { get;  set; }

        public Staff()
        {
        }
    }
}