using System.Collections.Generic;
using kursach.BLL.DTO;

namespace kursach.BLL.Interfaces
{
    public interface IDepartmentService
    {
        void AddDepartment(DepartmentDTO departmentDto);
        void ChangeDepartment(int? id, DepartmentDTO newDepartment);
        DepartmentDTO GetDepartment(int? departmentId);
        IEnumerable<DepartmentDTO> GetAllDepartments();
        IEnumerable<WorkerDTO> GetWorkers(int? departmentId);
        void Dispose();
    }
}