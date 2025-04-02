using FluentValidation;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaAPI.Services.Services
{
    class OrderProductService : BaseService<OrderProduct>
    {
        public OrderProductService(IRepository<OrderProduct> orderProductRepository, IValidator<OrderProduct> orderProductValidator) : base(orderProductRepository, orderProductValidator)
        {
        }
    }
}
