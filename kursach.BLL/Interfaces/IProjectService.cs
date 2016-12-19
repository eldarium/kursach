using System;
using System.Collections.Generic;
using kursach.BLL.DTO;

namespace kursach.BLL.Interfaces
{
    public interface IProjectService
    {
        void AddProject(ProjectDTO project);
        void ChangeProject(int? projectId, ProjectDTO newProject);
        IEnumerable<ProjectDTO> Find(Func<ProjectDTO, bool> predicate);
        IEnumerable<WorkerDTO> GetAllWorkers(int? id);
        IEnumerable<ProjectDTO> GetAllProjects();
    }
}