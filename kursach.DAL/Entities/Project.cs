using System.Collections.Generic;

namespace kursach.DAL.Entities
{
    public class Project : CompanyEntity
    {
        public int ProjectId { get; set; }
        public string Name { get;  set; }
        public decimal Cost { get;  set; }

        public ICollection<Worker> AssignedWorkers { get; set; }
        public Project() {
            AssignedWorkers = new List<Worker>();
        }
    }
}