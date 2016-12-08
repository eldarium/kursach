using System.Collections.Generic;
using kursach.BLL.DTO;

namespace kursach.BLL.Interfaces
{
    public interface IDepartmentService
    {
        void AddDepartment(DepartmentDTO departmentDto);
        void ChangeDepartment(int? id);
        DepartmentDTO GetDepartment(int? id);
        IEnumerable<WorkerDTO> GetWorkers();
        void Dispose();
    }
}