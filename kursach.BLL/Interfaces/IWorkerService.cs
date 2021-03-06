﻿using System;
using System.Collections.Generic;
using kursach.BLL.DTO;

namespace kursach.BLL.Interfaces
{
    public interface IWorkerService
    {
        void AddWorker(WorkerDTO workerDto);
        void RemoveWorker(int? id);
        void ChangeWorker(int? id, WorkerDTO newWorker);
        IEnumerable<WorkerDTO> Find(Func<WorkerDTO, bool> predicate);
        WorkerDTO GetWorker(int? id);
        IEnumerable<WorkerDTO> GetAllWorkers();
        IEnumerable<ProjectDTO> GetProjects(int? workerId); 
        void Dispose();
    }
}