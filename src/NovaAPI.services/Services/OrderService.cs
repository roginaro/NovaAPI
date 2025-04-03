using FluentValidation;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Interfaces;

namespace NovaAPI.Services.Services
{
    class OrderService : BaseService<Order>
    {
        public OrderService(IRepository<Order> orderRepository, IValidator<Order> orderValidator) : base(orderRepository, orderValidator)
        {
        }
    }
}
