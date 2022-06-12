using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.WebApi;
using Unity.Mvc5;
using QualifyMeProject.ServiceLayer;

namespace QualifyMeProject
{

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IUsersService, UsersService>();
            container.RegisterType<ICompanyUsersService, CompanyUsersService>();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);


        }
    }
}