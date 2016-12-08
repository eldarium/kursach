using System.Collections.Generic;

namespace kursach.DAL.Entities
{
    public class Department : CompanyEntity
    {
        private ISet<Worker> AssignedWorkers;
        public int DepartmentId { get;  set; }
        public string Name { get;  set; }

        public Department()
        {
        }

    }
}