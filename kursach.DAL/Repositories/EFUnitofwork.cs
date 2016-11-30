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
    class EFUnitofwork : IUnitofwork
    {
        private CompanyContext db;
        private WorkerRepository workerRepository;
        private StaffRepository staffRepository;
        private DepartmentRepository departmentRepository;
        public EFUnitofwork()
        {
            db = new CompanyContext();
        }

        public IRepository<Worker> Workers => workerRepository ?? new WorkerRepository(db);

        public IRepository<Department> Departments => departmentRepository ?? new DepartmentRepository(db);

        public IRepository<Staff> Staffs => staffRepository ?? new StaffRepository(db);

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed;

        public virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if(disposing)
                db.Dispose();
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
