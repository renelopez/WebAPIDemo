﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using WebApiDemo.Data;
using System.Web.Http.Cors;

namespace WebApiDemo.Services
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            var cors = new EnableCorsAttribute("*", "*", "*") {SupportsCredentials = true};
            config.EnableCors(cors);
            config.Routes.MapHttpRoute(
                name: "BreezeApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );


            // Creating the builder.
            var builder = new ContainerBuilder();


            // Registering controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Registering repositories
            builder.RegisterType<Repository>().As<IRepository>().InstancePerLifetimeScope();
            builder.RegisterType<WebAPIDemoContext>().As<WebAPIDemoContext>().InstancePerLifetimeScope();

            var container = builder.Build();
            config.DependencyResolver=new AutofacWebApiDependencyResolver(container);
            appBuilder.UseWebApi(config);
        }
    } 
}
