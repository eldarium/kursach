using kursach.BLL.Interfaces;
using kursach.BLL.Services;
using Ninject.Modules;

namespace kursach.Util
{
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWorkerService>().To<WorkerService>().InTransientScope();
            Bind<IDepartmentService>().To<DepartmentService>().InTransientScope();
            Bind<IProjectService>().To<ProjectService>().InTransientScope();
            Bind<IStaffService>().To<StaffService>().InTransientScope();
        }
    }
}