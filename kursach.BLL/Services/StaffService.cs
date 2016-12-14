using System.Collections.Generic;
using AutoMapper;
using kursach.BLL.DTO;
using kursach.BLL.Interfaces;
using kursach.DAL.Entities;
using kursach.DAL.Interfaces;

namespace kursach.BLL.Services
{
    public class StaffService :IStaffService
    {
        IUnitofwork Database { get; }

        public StaffService(IUnitofwork db)
        {
            Database = db;
        }
        public void ChangeStaff(int? id, StaffDTO newStaff)
        {
            if (id == null) return;
            var toc = Database.Staffs.Get(id.Value);
            if (toc == null) return;
            Mapper.Initialize(cfg => cfg.CreateMap<StaffDTO, Staff>());
            toc = Mapper.Map<StaffDTO, Staff>(newStaff);
            Database.Save();
        }

        public IEnumerable<StaffDTO> GetAllStaff()
        {

            Mapper.Initialize(cfg => cfg.CreateMap<Staff, StaffDTO>());
            return Mapper.Map<IEnumerable<Staff>, IEnumerable<StaffDTO>>(Database.Staffs.GetAll());
        }
    }
}