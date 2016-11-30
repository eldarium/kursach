namespace kursach.DAL.DataWorkers
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
                    context.Database.ExecuteSqlCommand(string.Format((string) "DELETE FROM {0}", (object) tableName));
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
