using BAL.Interface;
using BAL.Interfaces;
using BAL.Manager;
using BAL.Managers;
using DAL;
using DAL.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace webApiTask
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InjectorContainer();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        private void InjectorContainer()
        {
            try
            {
                var container = new Container();
                container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

                container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
                container.Register<IUserManager, UserManager>();
                container.Register<IToDoListManager, ToDoListManager>();
                container.Register<IToDoItemManager, ToDoItemManager>();

                container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
                GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
