using System.Collections.Generic;

namespace kursach.Models
{
    public class ProjectViewModel
    {
        public int ProjectID { get; private set; }
        public string Name { get; private set; }
        public ISet<WorkerViewModel> AssignedWorkers { get; set; }
        public decimal Cost { get; private set; }

    }
}