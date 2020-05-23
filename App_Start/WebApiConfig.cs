
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace VidlyProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //indentation settings for Json object
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;


            config.MapHttpAttributeRoutes();
            //Enabling CORS
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
