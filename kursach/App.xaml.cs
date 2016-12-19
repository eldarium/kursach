using System;
using System.Windows;
using AutoMapper;
using Ninject;
using kursach.BLL.Interfaces;
using kursach.BLL.Infrastructure;
using kursach.BLL.Services;
using kursach.Util;
using Ninject.Modules;
using kursach.BLL.DTO;
using kursach.DAL.Entities;
using kursach.Models;
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
            Mapper.Initialize(cfg =>
            {
                //dal => bl
                cfg.CreateMap<Worker, WorkerDTO>();
                cfg.CreateMap<Department, DepartmentDTO>();
                cfg.CreateMap<Staff, StaffDTO>();
                cfg.CreateMap<Project, ProjectDTO>();

                //bl => dal
                cfg.CreateMap<Worker, WorkerDTO>().ReverseMap();
                cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
                cfg.CreateMap<Staff, StaffDTO>().ReverseMap();
                cfg.CreateMap<Project, ProjectDTO>().ReverseMap();

                // bl => pl
                cfg.CreateMap<WorkerDTO, WorkerViewModel>();
                cfg.CreateMap<DepartmentDTO, DepartmentViewModel>();
                cfg.CreateMap<StaffDTO, StaffViewModel>();
                cfg.CreateMap<ProjectDTO, ProjectViewModel>();

                //pl => bl
                cfg.CreateMap<WorkerDTO, WorkerViewModel>().ReverseMap();
                cfg.CreateMap<DepartmentDTO, DepartmentViewModel>().ReverseMap();
                cfg.CreateMap<StaffDTO, StaffViewModel>().ReverseMap();
                cfg.CreateMap<ProjectDTO, ProjectViewModel>().ReverseMap();
            });
        }

        private void ConfigureContainer()
        {
            var modules = new INinjectModule[] { new ServiceModule("CompanyConnection"), new MainModule() };
            var kernel = new StandardKernel(modules);
        }
    }
}