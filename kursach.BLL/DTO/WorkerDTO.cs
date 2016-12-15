using System;
using System.Collections.Generic;

namespace kursach.BLL.DTO
{
    public class WorkerDTO
    {
        private DateTime _assignDay;
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long BankAccount { get; set; }
        public IEnumerable<ProjectDTO> Projects { get; set; }
        public DepartmentDTO AssignedDepartment { get; set; }
        public StaffDTO AssignedPosition { get; set; }
        public double Age => (DateTime.Today - _assignDay).TotalDays; //?

        public WorkerDTO() { }
    }
}
