using System;
using System.Collections.Generic;

namespace kursach.DAL.Entities
{
    public class Worker : CompanyEntity
    {   
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get;  set; }
        public long BankAccount { get;  set; }
        public ICollection<Project> WorkerProjects { get;  set; } 
        public Department AssignedDepartment { get;  set; }
        public Staff AssignedPosition { get;  set; }
        public double Age =>1; //?

        public Worker()
        {
            this.WorkerProjects = new List<Project>();
        }

    }
}