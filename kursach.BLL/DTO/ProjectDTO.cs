using System.Collections.Generic;

namespace kursach.BLL.DTO
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public ICollection<WorkerDTO> AssignedWorkers { get; set; }
        public ProjectDTO() { }
    }
}