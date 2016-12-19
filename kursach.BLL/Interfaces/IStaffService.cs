using System;
using System.Collections.Generic;
using kursach.BLL.DTO;

namespace kursach.BLL.Interfaces
{
    public interface IStaffService
    {
        void AddStaff(StaffDTO staff);
        void ChangeStaff(int? id, StaffDTO newStaff);
        IEnumerable<StaffDTO> Find(Func<StaffDTO, bool> predicate);
        IEnumerable<StaffDTO> GetAllStaff();
        IEnumerable<WorkerDTO> GetAllWorkers(int? staffId);
    }
}