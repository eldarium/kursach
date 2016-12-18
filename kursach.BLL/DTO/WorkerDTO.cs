using System;
using System.Collections.Generic;

namespace kursach.BLL.DTO
{
    public class WorkerDTO
    {
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long BankAccount { get; set; }
        public ICollection<ProjectDTO> WorkerProjects { get; set; }
        public DepartmentDTO AssignedDepartment { get; set; }
        public StaffDTO AssignedPosition { get; set; }
        public double Age => 1; //?

        public WorkerDTO() { }
    }
}
