using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Classes;

namespace kursach.DataWorkers
{
    public static class MainWorker
    {
        public static void AddWorker(Worker a)
        {
            using (var context = new WorkerContext())
            {
                context.Workers.Load();
                context.Workers.Add(a);
                context.SaveChanges();
            }
        }

        public static void ClearAll()
        {
            using (var context = new WorkerContext())
            {
                var tableNames = context.Database.SqlQuery<string>("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME NOT LIKE '%Migration%'").ToList();
                foreach (var tableName in tableNames)
                {
                    context.Database.ExecuteSqlCommand(string.Format("DELETE FROM {0}", tableName));
                }

                context.SaveChanges();
            }
        }

        public static void RemoveWorker(Worker a)
        {
            using (var context = new WorkerContext())
            {
                context.Workers.Load();
                context.Workers.Remove(a);
                context.SaveChanges();
            }
        }
    }
}
