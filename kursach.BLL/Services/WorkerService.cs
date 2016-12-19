using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using kursach.BLL.DTO;
using kursach.BLL.Infrastructure;
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
            Worker w = Mapper.Map<WorkerDTO, Worker>(workerDto);
            Database.Workers.Create(w);
            Database.Save();
        }
        public void RemoveWorker(int? id)
        {
            if (id == null) throw new CompanyException("Не задано ID робітника");
            Database.Workers.Delete(id.Value);
            Database.Save();
        }

        public void ChangeWorker(int? id, WorkerDTO newWorker)
        {
            if (id == null) throw new CompanyException("Не задано ID робітника");
            var toc = Database.Workers.Get(id.Value);
            if (toc == null) throw new CompanyException("Робітника з id " + Convert.ToString(id.Value) + " не знайдено");
            toc = Mapper.Map(newWorker, toc);
            Database.Save();
        }

        public WorkerDTO GetWorker(int? id)
        {
            if (id == null) throw new CompanyException("Не задано ID робітника");
            var w = Mapper.Map<Worker, WorkerDTO>(Database.Workers.Get(id.Value));
            if(w == null) throw new CompanyException("Робітника з id " + Convert.ToString(id.Value) + " не знайдено");
            return w;
        }

        public IEnumerable<WorkerDTO> Find(Func<WorkerDTO, bool> predicate)
        {

            return Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerDTO>>(Database.Workers.GetAll()).Where(predicate);
        }

        public IEnumerable<WorkerDTO> GetAllWorkers()
        {
            return Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerDTO>>(Database.Workers.GetAll());
        }

        public IEnumerable<ProjectDTO> GetProjects(int? workerId)
        {
            if (workerId == null) throw new CompanyException("Не задано ID робітника");
            var w = (Database.Workers.Get(workerId.Value));
            if (w == null) throw new CompanyException("Робітника з id " + Convert.ToString(workerId.Value) + " не знайдено");
            return Mapper.Map<ICollection<Project>, ICollection<ProjectDTO>>(w.Projects);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}