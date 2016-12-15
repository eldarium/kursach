namespace kursach.DAL.Entities
{
    public class Project : CompanyEntity
    {
        public int ProjectID { get; private set; }
        public string Name { get;  set; }
        public decimal Cost { get;  set; }
        public Project() { }
    }
}