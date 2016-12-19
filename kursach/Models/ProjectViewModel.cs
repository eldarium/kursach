using System.Collections.Generic;

namespace kursach.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WorkerViewModel> AssignedWorkers { get; set; }
        public decimal Cost { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}