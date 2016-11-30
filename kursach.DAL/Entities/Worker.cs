using System;

namespace kursach.DAL.Entities
{
    public class Worker : CompanyEntity
    {
        private DateTime _assignDay;
        public int WorkerId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public long BankAccount { get; private set; }
        public Department AssignedDepartment { get; private set; }
        public Staff AssignedPosition { get; private set; }
        public double Age => (DateTime.Today - _assignDay).TotalDays; //?

        private Worker()
        {
        }

    }
}