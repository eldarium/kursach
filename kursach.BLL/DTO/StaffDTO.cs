using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach.BLL.DTO
{
    public class StaffDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public double WorkTime { get; set; }
        public ICollection<WorkerDTO> AssignedWorkers { get; set; }
        public StaffDTO() { }
    }
}
