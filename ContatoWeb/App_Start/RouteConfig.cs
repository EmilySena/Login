using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ContatoWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Cadastro",
                url: "Contato/Cadastro",
                defaults: new { controller = "Contato", action = "Create"}
            );
            routes.MapRoute(
                name: "Default",
                url: "Contato/Index",
                defaults: new { controller = "Contato", action = "Index"}
            );
            routes.MapRoute(
                name: "Create",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Contato", action = "Create", id = UrlParameter.Optional }
            );
        }
    }
}
