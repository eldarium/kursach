using System.Collections.Generic;
using AutoMapper;
using kursach.BLL.DTO;
using kursach.BLL.Interfaces;
using kursach.DAL.Entities;
using kursach.DAL.Interfaces;
using System.Linq;

namespace kursach.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        IUnitofwork Database { get; }

        public DepartmentService(IUnitofwork db)
        {
            Database = db;
        }
        public void AddDepartment(DepartmentDTO departmentDto)
        {
            Mapper.Initialize(cfg=>cfg.CreateMap<DepartmentDTO, Department>());
            var d = Mapper.Map<DepartmentDTO, Department>(departmentDto);
            Database.Departments.Create(d);
            Database.Save();
        }

        public void ChangeDepartment(int? id, DepartmentDTO newDepartment)
        {
            if (id == null) return;
            var toc = Database.Departments.Get(id.Value);
            if (toc == null) return;
            Mapper.Initialize(cfg => cfg.CreateMap<DepartmentDTO, Department>());
            toc = Mapper.Map<DepartmentDTO, Department>(newDepartment);
            Database.Save();
        }

        public DepartmentDTO GetDepartment(int? departmentId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Department, DepartmentDTO>());
            return departmentId != null ? 
                Mapper.Map<Department, DepartmentDTO>(Database.Departments.Get(departmentId.Value)) 
                : null;
        }

        public IEnumerable<WorkerDTO> GetWorkers(int? departmentId)
        {
            var dwork = from workers in Database.Workers.GetAll()
                where workers.AssignedDepartment.DepartmentId == departmentId
                select workers;
            Mapper.Initialize(cfg => cfg.CreateMap<Worker, WorkerDTO>());
            return Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerDTO>>(dwork);
        }

        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Department, DepartmentDTO>());
            return Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDTO>>(Database.Departments.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}