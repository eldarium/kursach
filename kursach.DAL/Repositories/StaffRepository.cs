using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.DAL.Entities;
using kursach.DAL.Interfaces;
using kursach.DAL.Contexts;

namespace kursach.DAL.Repositories
{
    class StaffRepository : IRepository<Staff>
    {
        private CompanyContext db;

        public StaffRepository(CompanyContext db)
        {
            this.db = db;
        }
        public IEnumerable<Staff> GetAll()
        {
            return db.Staffs;
        }

        public Staff Get(int id)
        {
            return db.Staffs.Find(id);
        }

        public IEnumerable<Staff> Find(Func<Staff, bool> predicate)
        {
            return db.Staffs.Where(predicate).ToList();
        }

        public void Create(Staff item)
        {
            db.Staffs.Add(item);
        }

        public void Update(Staff item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var staff = db.Staffs.Find(id);
            if (staff != null) db.Staffs.Remove(staff);
        }
    }
}
