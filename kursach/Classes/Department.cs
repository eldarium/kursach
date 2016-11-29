using System.Collections.Generic;

namespace kursach.Classes
{
    public class Department : CompanyEntity
    {
        private Department() { }
        public Department(string name)
        {
            Name = name;
        }

        public int DepartmentId { get; private set; }
        public string Name { get; private set; }

        private HashSet<Worker> AssignedWorkers;

        protected bool Equals(Department other)
        {
            return DepartmentId == other.DepartmentId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Department) obj);
        }

        public override int GetHashCode()
        {
            return DepartmentId;
        }

        public static bool operator ==(Department left, Department right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Department left, Department right)
        {
            return !Equals(left, right);
        }
    }
}
