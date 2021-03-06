﻿
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EventManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API yapılandırması ve hizmetleri

            // Web API yolları
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // force Web API to output JSON response only
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                new MediaTypeHeaderValue("text/html"));

            // solves CORS problem
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200", "*", "*"));

        }
    }
}
