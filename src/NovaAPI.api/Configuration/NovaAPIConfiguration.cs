using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NovaAPI.Repositories.Interfaces;
using NovaAPI.Repositories.Repositories;
using NovaAPI.Services.Interfaces.Materials;
using NovaAPI.Services.Services;
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
