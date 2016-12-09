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
        IUnitofwork Database { get; set; }

        public WorkerService(IUnitofwork db)
        {
            Database = db;
        }
        public void AddWorker(WorkerDTO workerDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<WorkerDTO, Worker>());
            Worker w = Mapper.Map<WorkerDTO, Worker>(workerDto);
            Database.Workers.Create(w);
        }

        public void RemoveWorker(int? id)
        {
            if (id != null) Database.Workers.Delete(id.Value);
            
        }

        public void ChangeWorker(int? id, WorkerDTO newWorker)
        {
            if (id == null) return;
            var toc = Database.Workers.Get(id.Value);
            if (toc == null) return;
            Mapper.Initialize(cfg => cfg.CreateMap<WorkerDTO, Worker>());
            toc = Mapper.Map<WorkerDTO, Worker>(newWorker);
            Database.Save();
        }

        public WorkerDTO GetWorker(int? id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Worker, WorkerDTO>());
            return id != null ? Mapper.Map<Worker, WorkerDTO>(Database.Workers.Get(id.Value)) : null;
        }

        public IEnumerable<WorkerDTO> GetWorkers()
        {
            Mapper.Initialize(cfg=>cfg.CreateMap<Worker, WorkerDTO>());
            return Mapper.Map<IEnumerable<Worker>, List<WorkerDTO>>(Database.Workers.GetAll());
        }

        public IEnumerable<ProjectDTO> GetProjects(int? workerId)
        {
            Mapper.Initialize(cfg=>cfg.CreateMap<Project,ProjectDTO>());
            return workerId != null ? Mapper.Map<IEnumerable<Project>, List<ProjectDTO>>(Database.Workers.Get(workerId.Value).Projects) : null;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}