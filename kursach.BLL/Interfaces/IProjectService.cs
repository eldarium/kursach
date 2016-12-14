using System.Collections.Generic;
using kursach.BLL.DTO;

namespace kursach.BLL.Interfaces
{
    public interface IProjectService
    {
        void AddProject(ProjectDTO project);

        IEnumerable<ProjectDTO> GetAllProjects();
    }
}