using System;
using System.Collections.Generic;
using kursach.BLL.DTO;

namespace kursach.BLL.Interfaces
{
    public interface IDepartmentService
    {
        void AddDepartment(DepartmentDTO departmentDto);
        void ChangeDepartment(int? id, DepartmentDTO newDepartment);
        IEnumerable<DepartmentDTO> Find(Func<DepartmentDTO, bool> predicate);
        DepartmentDTO GetDepartment(int? departmentId);
        IEnumerable<DepartmentDTO> GetAllDepartments();
        IEnumerable<WorkerDTO> GetWorkers(int? departmentId);
        void Dispose();
    }
}