using Autofac;
using JBHiFi.Services;
using JBHiFi.Repositories;

namespace JBHiFi
{
    public class IoCBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();

            return builder.Build();
        }
    }
}