using System.Collections.Generic;
using kursach.BLL.DTO;
using kursach.BLL.Interfaces;
using AutoMapper;
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

        public IEnumerable<ProjectDTO> GetAllProjects()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectDTO>());
            return Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(Database.Projects.GetAll());
        }
    }
}