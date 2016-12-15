using System;
using System.Windows;
using Ninject;
using kursach.BLL.Interfaces;
using kursach.BLL.Infrastructure;
using kursach.BLL.Services;
using kursach.Util;
using Ninject.Modules;

namespace kursach
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
        }

        private void ConfigureContainer()
        {
            var modules = new INinjectModule[] { new ServiceModule("CompanyConnection"), new MainModule() };
            var kernel = new StandardKernel(modules);
        }
    }
}