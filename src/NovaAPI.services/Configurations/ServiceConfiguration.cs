using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NovaAPI.Entities.Models;
using NovaAPI.Services.Interfaces.Materials;
using NovaAPI.Services.Services;
using NovaAPI.Services.Validations;
namespace NovaAPI.Services.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IService<Customer>, CustomerService>();
            services.AddScoped<IService<Order>, OrderService>();
            services.AddScoped<IService<OrderProduct>, OrderProductService>();
            services.AddScoped<IService<Product>, ProductService>();
            services.AddScoped<IValidator<Order>, OrderValidation>();
            services.AddScoped<IValidator<Customer>, CustomerValidation>();
            services.AddScoped<IValidator<OrderProduct>, OrderProductValidation>();
            services.AddScoped<IValidator<Product>, ProductValidation>();
            return services;
        }
    }
}
