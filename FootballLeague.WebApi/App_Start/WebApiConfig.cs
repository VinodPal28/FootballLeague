using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using FootballLeague.Data.Services;
using FootballLeague.Data.Services.Implementations;
using System.Web.Http.ExceptionHandling;
using FootballLeague.WebApi.ExceptionHandler.CustomHandler;

namespace FootballLeague.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.

            //Registering UnhandledExceptionLogger
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
