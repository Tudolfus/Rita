using BL;
using BL.Parsers;
using Core.Interfaces.Parsers;
using Core.Interfaces.Products;
using Core.Models.Configuration;
using Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ira.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.Configure<ConnectionStringsModel>(options =>
            {
                options.Dev = configuration.GetConnectionString("Dev");
            });

            services.AddTransient<IParser, SberMarketParser>();
            services.AddTransient<IProductsDB, ProductsDB>();
            services.AddTransient<IProductBL, ProductBL>();

            return services;
        }
    }
}