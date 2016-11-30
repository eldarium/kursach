using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.DAL.Contexts;
using kursach.DAL.Entities;
using kursach.DAL.Interfaces;

namespace kursach.DAL.Repositories
{
    class DepartmentRepository : IRepository<Department>
    {
        private CompanyContext db;

        public DepartmentRepository(CompanyContext db)
        {
            this.db = db;
        }
        public IEnumerable<Department> GetAll()
        {
            return db.Departments;
        }

        public Department Get(int id)
        {
            return db.Departments.Find(id);
        }

        public IEnumerable<Department> Find(Func<Department, bool> predicate)
        {
            return db.Departments.Where(predicate).ToList();
        }

        public void Create(Department item)
        {
            db.Departments.Add(item);
        }

        public void Update(Department item)
        {
            db.Entry(item).State=EntityState.Modified;
        }

        public void Delete(int id)
        {
            var dept = db.Departments.Find(id);
            if (dept != null) db.Departments.Remove(dept);
        }
    }
}
