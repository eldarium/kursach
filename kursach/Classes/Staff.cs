using System.Collections.Generic;

namespace kursach.Classes
{
    public class Staff : CompanyEntity
    {
        private Staff() { }
        public Staff(string name)
        {
            Name = name;
        }

        private HashSet<Worker> AssignedWorkers;
        public int StaffId { get; private set; }
        public string Name { get; private set; }

        protected bool Equals(Staff other)
        {
            return StaffId == other.StaffId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Staff) obj);
        }

        public override int GetHashCode()
        {
            return StaffId;
        }

        public static bool operator ==(Staff left, Staff right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Staff left, Staff right)
        {
            return !Equals(left, right);
        }
    }
}
