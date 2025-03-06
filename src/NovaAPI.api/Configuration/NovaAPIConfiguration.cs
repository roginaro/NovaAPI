using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NovaAPI.repositories.Interfaces;
using NovaAPI.repositories.Repositories;
using NovaAPI.services.Interfaces.Materials;
using NovaAPI.services.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NovaAPI.api.Configuration
{
    public static class NovaAPIConfiguration
    {
        public static IServiceCollection AddNovaAPIConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProdutoRepository>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
