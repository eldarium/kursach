using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using kursach.BLL.DTO;
using kursach.BLL.Infrastructure;
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

        public void AddStaff(StaffDTO staff)
        {
            var s = Mapper.Map<StaffDTO, Staff>(staff);
            Database.Staffs.Create(s);
            Database.Save();
        }

        public void ChangeStaff(int? id, StaffDTO newStaff)
        {
            if (id == null) throw new CompanyException("Не задано ID посади");
            var toc = Database.Staffs.Get(id.Value);
            if (toc == null) throw new CompanyException("Посаду з id " + Convert.ToString(id.Value) + " не знайдено");
            toc = Mapper.Map<StaffDTO, Staff>(newStaff);
            Database.Staffs.Update(toc);
            Database.Save();
        }

        public IEnumerable<WorkerDTO> GetAllWorkers(int? staffId)
        {
            if (staffId == null) throw new CompanyException("Не задано ID підрозділу");
            var dwork = from workers in Database.Workers.GetAll()
                        where workers.AssignedPosition.Id == staffId
                        select workers;
            return Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerDTO>>(dwork);
        }

        public IEnumerable<StaffDTO> Find(Func<StaffDTO, bool> predicate)
        {
            return Mapper.Map<IEnumerable<Staff>, IEnumerable<StaffDTO>>(Database.Staffs.GetAll()).Where(predicate);
        }

        public IEnumerable<StaffDTO> GetAllStaff()
        {
            return Mapper.Map<IEnumerable<Staff>, IEnumerable<StaffDTO>>(Database.Staffs.GetAll());
        }
    }
}