using System;
using System.Collections.Generic;

namespace kursach.DAL.Entities
{
    public class Worker : CompanyEntity
    {
        private DateTime _assignDay;
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get;  set; }
        public long BankAccount { get;  set; }
        public IEnumerable<Project> Projects { get;  set; } 
        public Department AssignedDepartment { get;  set; }
        public Staff AssignedPosition { get;  set; }
        public double Age => (DateTime.Today - _assignDay).TotalDays; //?

        public Worker()
        {
        }

    }
}