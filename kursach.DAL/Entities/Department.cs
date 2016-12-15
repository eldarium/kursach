using System.Collections.Generic;

namespace kursach.DAL.Entities
{
    public class Department : CompanyEntity
    {
        public int DepartmentId { get; set; }
        public string Name { get;  set; }

        public Department()
        {
        }

    }
}