using System.Collections.Generic;

namespace kursach.DAL.Entities
{
    public class Department : CompanyEntity
    {
        private ISet<Worker> AssignedWorkers;
        public int DepartmentId { get; private set; }
        public string Name { get; private set; }

        private Department()
        {
        }

    }
}