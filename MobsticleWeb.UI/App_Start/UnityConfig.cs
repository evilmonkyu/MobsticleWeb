using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MobsticleWeb.Data;
using MobsticleWeb.Data.EF;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace MobsticleWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUserStore<IdentityUser>, UserStore<IdentityUser>>(new InjectionConstructor());
            container.RegisterType<UserManager<IdentityUser>>();
            container.RegisterType<IUnitOfWork, EFUnitOfWork>();
            container.RegisterType<MobsticleContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}