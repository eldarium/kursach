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
            Worker w = new Worker
            {
                Name = workerDto.Name,
                Surname = workerDto.Surname,
                AssignedDepartment =new Department {DepartmentId = workerDto.AssignedDepartment.DepartmentId, Name = workerDto.AssignedDepartment.Name},
                AssignedPosition = new Staff { Name=workerDto.AssignedPosition.Name, StaffId =workerDto.AssignedPosition.StaffId},
                BankAccount = workerDto.BankAccount,
                Projects = workerDto.Projects,
                WorkerId = workerDto.WorkerId
            };
            throw new System.NotImplementedException();
        }

        public void RemoveWorker(int? id)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeWorker(int? id)
        {
            throw new System.NotImplementedException();
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