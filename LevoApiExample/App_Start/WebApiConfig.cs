using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Autofac.Integration.WebApi;

namespace LevoApiExample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

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
