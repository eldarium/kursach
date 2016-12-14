using System;
using System.Collections.Generic;

namespace kursach.BLL.DTO
{
    public class WorkerDTO
    {
        private DateTime _assignDay;
        public int WorkerId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public long BankAccount { get; private set; }
        public IEnumerable<ProjectDTO> Projects { get; private set; }
        public DepartmentDTO AssignedDepartment { get; private set; }
        public StaffDTO AssignedPosition { get; private set; }
        public double Age => (DateTime.Today - _assignDay).TotalDays; //?
    }
}
