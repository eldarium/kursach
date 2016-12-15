using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using kursach.BLL.DTO;
using kursach.BLL.Interfaces;
using kursach.DAL.Entities;
using kursach.DAL.Interfaces;

namespace kursach.BLL.Services
{
    public class WorkerService : IWorkerService
    {
        IUnitofwork Database { get; }

        public WorkerService(IUnitofwork db)
        {
            Database = db;
        }
        public void AddWorker(WorkerDTO workerDto)
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<DepartmentDTO, Department>());
            //Mapper.Initialize(cfg => cfg.CreateMap<WorkerDTO, Worker>());
            Worker w = new Worker() {BankAccount =  workerDto.BankAccount, AssignedDepartment = new Department() { DepartmentId = workerDto.AssignedDepartment.DepartmentId, Name = workerDto.AssignedDepartment.Name}, AssignedPosition = new Staff() {Name = workerDto.AssignedPosition.Name, StaffId = workerDto.AssignedPosition.StaffId},Name = workerDto.Name, Surname = workerDto.Surname};
            Database.Workers.Create(w);
            Database.Save();
        }

        public void RemoveWorker(int? id)
        {
            if (id != null) Database.Workers.Delete(id.Value);
            Database.Save();

        }

        public void ChangeWorker(int? id, WorkerDTO newWorker)
        {
            if (id == null) return;
            var toc = Database.Workers.Get(id.Value);
            if (toc == null) return;
            Mapper.Initialize(cfg => cfg.CreateMap<WorkerDTO, Worker>());
            toc = Mapper.Map(newWorker,toc);
            Database.Save();
        }

        public WorkerDTO GetWorker(int? id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Worker, WorkerDTO>());
            return id != null ? Mapper.Map<Worker, WorkerDTO>(Database.Workers.Get(id.Value)) : null;
        }

        public IEnumerable<WorkerDTO> GetAllWorkers()
        {
            Mapper.Initialize(cfg=>cfg.CreateMap<Worker, WorkerDTO>());
            Mapper.Initialize(cfg => cfg.CreateMap<Department, DepartmentDTO>());
            return Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerDTO>>(Database.Workers.GetAll());
        }

        public IEnumerable<ProjectDTO> GetProjects(int? workerId)
        {
            Mapper.Initialize(cfg=>cfg.CreateMap<Project,ProjectDTO>());
            return workerId != null ? Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(Database.Workers.Get(workerId.Value).Projects) : null;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}