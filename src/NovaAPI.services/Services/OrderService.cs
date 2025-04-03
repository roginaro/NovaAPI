using FluentValidation;
using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Interfaces;

namespace NovaAPI.Services.Services
{
    class OrderService : BaseService<Order>
    {
        public OrderService(IRepository<Order> orderRepository, IValidator<Order> orderValidator) : base(orderRepository, orderValidator)
        {
        }
        public override async Task<ServiceOutput<Order>> Update(Order order)
        {
            ServiceOutput<Order> serviceOutput = new();
            var validationResult = _entityValidator.Validate(order);
            if (!validationResult.IsValid)
            {
                serviceOutput.Data = order;
                serviceOutput.Message = "Ocorreram erros na estrutura de validação";
                serviceOutput.Errors = (from x in validationResult.Errors
                                        select new ErrorBase()
                                        {
                                            Message = x.ErrorMessage
                                        }).ToList();
                return serviceOutput;
            }
            var repositoryOutput = await _entityRepository.Update(order);
            if (!repositoryOutput.Success)
            {
                serviceOutput.Message = repositoryOutput.Message;
                serviceOutput.Errors = new List<ErrorBase> { new ErrorBase { Message = repositoryOutput.Message } };
                return serviceOutput;
            }
            serviceOutput.Data = repositoryOutput.Data;
            serviceOutput.Message = repositoryOutput.Message;
            return serviceOutput;
        }
    }
}
