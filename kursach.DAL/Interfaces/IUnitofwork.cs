using System;
using kursach.DAL.Entities;

namespace kursach.DAL.Interfaces
{
    public interface IUnitofwork :IDisposable
    {
        IRepository<Worker> Workers { get; }
        IRepository<Department> Departments { get; }
        IRepository<Staff> Staffs { get; }

        void Save();
    }
}