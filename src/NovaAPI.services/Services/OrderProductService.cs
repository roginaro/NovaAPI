using FluentValidation;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Interfaces;

namespace NovaAPI.Services.Services
{
    class OrderProductService : BaseService<OrderProduct>
    {
        public OrderProductService(IRepository<OrderProduct> orderProductRepository, IValidator<OrderProduct> orderProductValidator) : base(orderProductRepository, orderProductValidator)
        {
        }
    }
}
