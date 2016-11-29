using System;

namespace kursach.Classes
{
    public class Worker : CompanyEntity
    {
        private Worker() { }
        public int WorkerId { get; private set; }

        private readonly DateTime _assignDay;
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public long BankAccount { get; private set; } 
        public Department AssignedDepartment { get; private set; }
        public Staff AssignedPosition { get; private set; }
        public double Age => (DateTime.Today - _assignDay).TotalDays;  //?

        public Worker(string name, string surname, long bankAccount, Department assignedDepartment, Staff assignedPosition)
        {
            Name = name;
            Surname = surname;
            BankAccount = bankAccount;
            AssignedDepartment = assignedDepartment;
            AssignedPosition = assignedPosition;
            _assignDay = DateTime.Today;
        }

        public void AssignDepartment(Department d)
        {
            this.AssignedDepartment = d;
        }

        public void AssignStaff(Staff s)
        {
            this.AssignedPosition = s;
        }

        protected bool Equals(Worker other)
        {
            return WorkerId == other.WorkerId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Worker) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (Surname?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ BankAccount.GetHashCode();
                hashCode = (hashCode*397) ^ (AssignedPosition?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Age.GetHashCode();
                hashCode = (hashCode*397) ^ (AssignedDepartment?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Worker left, Worker right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Worker left, Worker right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("Worker named {0} {1}, bank account {2}, have worked in {3} as {4} for {5}", Name,Surname,BankAccount,AssignedDepartment.Name,AssignedPosition.Name, Age);
        }
    }
}