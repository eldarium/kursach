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
    public class WorkerRepository :IRepository<Worker>
    {
        private CompanyContext db;
        public WorkerRepository(CompanyContext db)
        {
            this.db = db;
        }

        public IEnumerable<Worker> GetAll()
        {
            return db.Workers;
        }

        public Worker Get(int id)
        {
            return db.Workers.Find(id);
        }

        public IEnumerable<Worker> Find(Func<Worker, bool> predicate)
        {
            return db.Workers.Where(predicate).ToList();
        }

        public void Create(Worker item)
        {
            db.Entry(item).State = EntityState.Added;
        }

        public void Update(Worker item)
        {
            db.Entry(item).State=EntityState.Modified;
        }

        public void Delete(int id)
        {
            var dep = db.Workers.Find(id);
            db.Entry(dep).State = EntityState.Deleted;
        }
    }
}
