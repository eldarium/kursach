namespace kursach.DAL.Entities
{
    public class Project : CompanyEntity
    {
        public string Name { get;  set; }
        public decimal Cost { get;  set; }
        public Project() { }
    }
}