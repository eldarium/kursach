using System;
using System.Collections.Generic;
using AutoMapper;
using kursach.BLL.DTO;
using kursach.BLL.Interfaces;
using kursach.DAL.Entities;
using kursach.DAL.Interfaces;
using System.Linq;
using System.Reflection;
using kursach.BLL.Infrastructure;

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
            var d = Mapper.Map<DepartmentDTO, Department>(departmentDto);
            Database.Departments.Create(d);
            Database.Save();
        }

        public void ChangeDepartment(int? id, DepartmentDTO newDepartment)
        {
            if (id == null) throw new CompanyException("Не задано ID підрозділу");
            var toc = Database.Departments.Get(id.Value);
            if (toc == null) throw new CompanyException("Робітника з id " + Convert.ToString(id.Value) + " не знайдено");
            Database.Departments.Update(Mapper.Map<Department>(newDepartment));
            Database.Save();
        }

        public DepartmentDTO GetDepartment(int? departmentId)
        {
            if (departmentId == null) throw new CompanyException("Не задано ID підрозділу");
            var dept = Database.Departments.Get(departmentId.Value);
            if (dept == null) throw new CompanyException("Підрозділу з id " + Convert.ToString(departmentId.Value) + " не знайдено");
            return Mapper.Map<Department, DepartmentDTO>(dept);
        }

        public IEnumerable<DepartmentDTO> Find(Func<DepartmentDTO, bool> predicate)
        {
            return Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDTO>>(Database.Departments.GetAll()).Where(predicate);
        }

        public IEnumerable<WorkerDTO> GetWorkers(int? departmentId)
        {
            if (departmentId == null) throw new CompanyException("Не задано ID підрозділу");
            var dwork = from workers in Database.Workers.GetAll()
                where workers.AssignedDepartment.Id == departmentId
                select workers;
            return Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerDTO>>(dwork);
        }

        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            return Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDTO>>(Database.Departments.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}