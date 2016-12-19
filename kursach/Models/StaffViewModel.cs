using System.Collections.Generic;

namespace kursach.Models
{
    public class StaffViewModel
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public double Salary { get;  set; }

        public ICollection<WorkerViewModel> AssignedWorkers { get; set; }
        public double WorkTime { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}