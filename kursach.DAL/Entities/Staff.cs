using System.Collections.Generic;

namespace kursach.DAL.Entities
{
    public class Staff : CompanyEntity
    {
        public int StaffId { get;  set; }
        public string Name { get;  set; }
        public double Salary { get; set; }
        public double WorkTime { get;  set; }

        private ICollection<Worker> AssignedWorkers { get; set; }

        public Staff()
        {
        }
    }
}