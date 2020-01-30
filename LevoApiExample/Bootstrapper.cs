using Autofac;
using Autofac.Integration.WebApi;
using LevoApiExample.Models;
using System.Reflection;

namespace LevoApiExample
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationDbContext>().AsSelf();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            return builder.Build();
        }
    }
}