using System.Collections.Generic;

namespace kursach.Models
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; private set; }
        public string Name { get; private set; }
        public ISet<WorkerViewModel> AssignedWorkers { get; set; }
    }
}