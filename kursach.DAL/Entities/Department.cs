using System.Collections.Generic;

namespace kursach.DAL.Entities
{
    public class Department : CompanyEntity
    {
        public int Id { get; set; }
        public string Name { get;  set; }

        public ICollection<Worker> AssignedWorkers { get; set; }
        public Department()
        {
            AssignedWorkers = new List<Worker>();
        }

    }
}