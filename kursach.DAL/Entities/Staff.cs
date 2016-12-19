using System.Collections.Generic;

namespace kursach.DAL.Entities
{
    public class Staff : CompanyEntity
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public double Salary { get; set; }
        public double WorkTime { get;  set; }

        public ICollection<Worker> AssignedWorkers { get; set; }

        public Staff()
        {
        }
    }
}