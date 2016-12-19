using System;
using System.Collections.Generic;
using System.Linq;
using kursach.BLL.DTO;
using kursach.BLL.Interfaces;
using AutoMapper;
using kursach.BLL.Infrastructure;
using kursach.DAL.Entities;
using kursach.DAL.Interfaces;

namespace kursach.BLL.Services
{
    public class ProjectService : IProjectService
    {
        IUnitofwork Database { get; }

        public ProjectService(IUnitofwork db)
        {
            Database = db;
        }
        public void AddProject(ProjectDTO project)
        {

            Mapper.Initialize(cfg => cfg.CreateMap<ProjectDTO, Project>());
            var w = Mapper.Map<ProjectDTO, Project>(project);
            Database.Projects.Create(w);
            Database.Save();
        }

        public void ChangeProject(int? projectId, ProjectDTO newProject)
        {
            if (projectId == null) throw new CompanyException("Не задано ID проекту");
            var toc = Database.Projects.Get(projectId.Value);
            if (toc == null) throw new CompanyException("Проекту з id " + Convert.ToString(projectId.Value) + " не знайдено");
            Database.Projects.Update(Mapper.Map<Project>(newProject));
            Database.Save();
        }

        public IEnumerable<WorkerDTO> GetAllWorkers(int? id)
        {
            if (id == null) throw new CompanyException("Не задано ID проекту");
            var dwork = from workers in Database.Workers.GetAll()
                        where workers.Projects.Count(x=>x.Id==id)>0
                        select workers;
            return Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerDTO>>(dwork);
        }

        public IEnumerable<ProjectDTO> Find(Func<ProjectDTO, bool> predicate)
        {

            return Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(Database.Projects.GetAll()).Where(predicate);
        }

        public IEnumerable<ProjectDTO> GetAllProjects()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectDTO>());
            return Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(Database.Projects.GetAll());
        }
    }
}