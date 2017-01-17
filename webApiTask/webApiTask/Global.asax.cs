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
using System.Web.Http.Tracing;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using webApiTask.Helpers;

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

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

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

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

            // Get the exception object.
            Exception exc = Server.GetLastError().GetBaseException();

            // Handle HTTP errors
            var httpExc = exc as HttpException;
                if(httpExc.ErrorCode == 404)
            {

            }

            if (exc.GetType() == typeof(HttpException) )
            {
                // The Complete Error Handling Example generates
                // some errors using URLs with "NoCatch" in them;
                // ignore these here to simulate what would happen
                // if a global.asax handler were not implemented.
                if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
                    return;

                //Redirect HTTP errors to HttpError page
                throw new Exception();
            }

            // For other kinds of errors give the user some information
            // but stay on the default page
            Response.Write("<h2>Global Page Error</h2>\n");
            Response.Write(
                "<p>" + exc.Message + "</p>\n");
            Response.Write("Return to the <a href='Default.aspx'>" +
                "Default Page</a>\n");

            // Log the exception and notify system operators

            //ExceptionUtility.LogException(exc, "DefaultPage");
            //ExceptionUtility.NotifySystemOps(exc);

            GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());
            var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();

            throw new Exception();

            // Clear the error from the server
            Server.ClearError();
        }
    }
}
