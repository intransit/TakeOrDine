﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TakeOrDine
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/",
                defaults: new { }
                //defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}