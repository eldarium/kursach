using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using kursach.DAL.Contexts;
using kursach.DAL.Entities;
using kursach.DAL.Interfaces;

namespace kursach.DAL.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private CompanyContext db;

        public ProjectRepository(CompanyContext db)
        {
            this.db = db;
        }
        public IEnumerable<Project> GetAll()
        {
            return db.Projects;
        }

        public Project Get(int id)
        {
            return db.Projects.Find(id);
        }

        public IEnumerable<Project> Find(Func<Project, bool> predicate)
        {
            return db.Projects.Where(predicate).ToList();
        }

        public void Create(Project item)
        {
            db.Projects.Add(item);
        }

        public void Update(Project item)
        {
            db.Entry(item).State=EntityState.Modified;
        }

        public void Delete(int id)
        {
            var dep = db.Projects.Find(id);
            db.Entry(dep).State = EntityState.Deleted;
        }
    }
}