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
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Worker, WorkerDTO>();
                cfg.CreateMap<Department, DepartmentDTO>();
                cfg.CreateMap<Staff, StaffDTO>();
                cfg.CreateMap<Project, ProjectDTO>();
                cfg.CreateMap<Worker, WorkerDTO>().ReverseMap();
                cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
                cfg.CreateMap<Staff, StaffDTO>().ReverseMap();
                cfg.CreateMap<Project, ProjectDTO>().ReverseMap();
            });
            Database = db;
        }
        public void AddWorker(WorkerDTO workerDto)
        {
            Worker w = Mapper.Map<WorkerDTO, Worker>(workerDto);
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
            toc = Mapper.Map(newWorker,toc);
            Database.Save();
        }

        public WorkerDTO GetWorker(int? id)
        {
            return id != null ? Mapper.Map<Worker, WorkerDTO>(Database.Workers.Get(id.Value)) : null;
        }

        public IEnumerable<WorkerDTO> GetAllWorkers()
        {
            return Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerDTO>>(Database.Workers.GetAll());
        }

        public IEnumerable<ProjectDTO> GetProjects(int? workerId)
        {
            return workerId != null ? Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(Database.Workers.Get(workerId.Value).Projects) : null;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}