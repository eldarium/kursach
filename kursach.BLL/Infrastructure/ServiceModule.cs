using kursach.DAL.Interfaces;
using kursach.DAL.Repositories;
using Ninject.Modules;

namespace kursach.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitofwork>().To<EFUnitofwork>().WithConstructorArgument(connectionString);
        }
    }
}