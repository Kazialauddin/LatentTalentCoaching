using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using w1.Controllers;
using w1.Interface;
using w1.Models;
using w1.Services;

namespace w1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IQuestionMakerService, QuestionMakerServices>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}