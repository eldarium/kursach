using System.Collections.Generic;
using kursach.BLL.DTO;

namespace kursach.BLL.Interfaces
{
    public interface IWorkerService
    {
        void AddWorker(WorkerDTO workerDto);
        void RemoveWorker(int? id);
        void ChangeWorker(int? id);
        WorkerDTO GetWorker(int? id);
        IEnumerable<WorkerDTO> GetWorkers();
        IEnumerable<ProjectDTO> GetProjects(int? workerId); 
        void Dispose();
    }
}