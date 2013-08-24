using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Students.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "StudentsApi",
                routeTemplate: "api/students/{id}/marks",
                defaults: new 
                { 
                    controller = "students",
                    action = "marks"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



            config.EnableCors(new EnableCorsAttribute("*","*","*"));
        }
    }
}
