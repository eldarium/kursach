using System.Collections.Generic;
using kursach.BLL.DTO;

namespace kursach.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WorkerViewModel> AssignedWorkers { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}