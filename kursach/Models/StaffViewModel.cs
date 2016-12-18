using System.Collections.Generic;

namespace kursach.Models
{
    public class StaffViewModel
    {
        public int StaffId { get; private set; }
        public string Name { get; private set; }
        public double Salary { get; private set; }

        public ISet<WorkerViewModel> AssignedWorkers { get; set; }
        public double WorkTime { get; private set; }
    }
}