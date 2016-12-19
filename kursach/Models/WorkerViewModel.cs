using System;
using System.Collections.Generic;

namespace kursach.Models
{
    public class WorkerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long BankAccount { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<ProjectViewModel> WorkerProjects { get; set; }
        public DepartmentViewModel AssignedDepartment { get; set; }
        public StaffViewModel AssignedPosition { get; set; }
        public double Age => (StartDate - DateTime.Today).Days; //?

        public override string ToString()
        {
            return string.Join(" ", Name, Surname);
        }
    }
}