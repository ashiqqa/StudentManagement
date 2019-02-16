using AutoMapper;
using SM.Models;
using StudentManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StudentManagementSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DepartmentVM, Department > ();
                cfg.CreateMap<Department, DepartmentVM>();

                cfg.CreateMap<Country, CountryVM>();
                cfg.CreateMap<CountryVM, Country>();

                cfg.CreateMap<City, CityVM>();
                cfg.CreateMap<CityVM, City>();

                cfg.CreateMap<Bank, BankVM>();
                cfg.CreateMap<BankVM, Bank>();

                cfg.CreateMap<Semister, SemisterVM>();
                cfg.CreateMap<SemisterVM, Semister>();

                cfg.CreateMap<Sesion, SesionVM>();
                cfg.CreateMap<SesionVM, Sesion>();

                cfg.CreateMap<Student, StudentVM>();
                cfg.CreateMap<StudentVM, Student>();
            });
        }

        //For Cache expired after logout
        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }
    }
}
