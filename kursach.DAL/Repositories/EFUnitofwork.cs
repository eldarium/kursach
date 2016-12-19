using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.DAL.Contexts;
using kursach.DAL.Entities;
using kursach.DAL.Interfaces;

namespace kursach.DAL.Repositories
{
    public class EfUnitofwork : IUnitofwork
    {
        private readonly CompanyContext _db;
        private WorkerRepository workerRepository;
        private StaffRepository staffRepository;
        private DepartmentRepository departmentRepository;
        private ProjectRepository projectRepository;
        public EfUnitofwork(string connectionString)
        {
            _db = new CompanyContext(connectionString);
        }

        public IRepository<Worker> Workers => workerRepository ?? (workerRepository = new WorkerRepository(_db));

        public IRepository<Department> Departments => departmentRepository ?? (departmentRepository = new DepartmentRepository(_db));

        public IRepository<Staff> Staffs => staffRepository ??(staffRepository = new StaffRepository(_db));

        public IRepository<Project> Projects => projectRepository ??(projectRepository = new ProjectRepository(_db)); 

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed;

        public virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if(disposing)
                _db.Dispose();
            disposed = true;
        }
        public void Dispose()
        {
            Save();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
