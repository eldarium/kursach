using System;
using System.Collections.Generic;

namespace kursach.Models
{
    public class WorkerViewModel
    {
        public int WorkerId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public long BankAccount { get; private set; }
        public IEnumerable<ProjectViewModel> Projects { get; private set; }
        public DepartmentViewModel AssignedDepartment { get; private set; }
        public StaffViewModel AssignedPosition { get; private set; }
        public double Age; //?
    }
}