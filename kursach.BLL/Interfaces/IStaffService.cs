using System.Collections.Generic;
using kursach.BLL.DTO;

namespace kursach.BLL.Interfaces
{
    public interface IStaffService
    {
        void ChangeStaff(int? id, StaffDTO newStaff);
        IEnumerable<StaffDTO> GetAllStaff();
    }
}