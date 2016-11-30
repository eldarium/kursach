﻿using System;
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
            db.Workers.Add(item);
        }

        public void Update(Worker item)
        {
            db.Entry(item).State=EntityState.Modified;
        }

        public void Delete(int id)
        {
            var worker = db.Workers.Find(id);
            if (worker != null) db.Workers.Remove(worker);
        }
    }
}