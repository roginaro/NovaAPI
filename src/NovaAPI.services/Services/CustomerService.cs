﻿using FluentValidation;
using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Interfaces;
using NovaAPI.Repositories.Repositories;
using NovaAPI.Services.Interfaces.Materials;


namespace NovaAPI.Services.Services
{
    public class CustomerService : BaseService<Customer, ICustomerRepository>, ICustomerService
    {
        private ICustomerRepository _customerRepository => (ICustomerRepository)_entityRepository;

        public CustomerService(ICustomerRepository entityRepository, IValidator<Customer> costumerValidator) : base(entityRepository, costumerValidator)
        {
        }

        public async Task<ServiceOutput<Customer>> Update(Customer customer)
        {
            ServiceOutput<Customer> serviceOutput = new();
            var validationResult = _entityValidator.Validate(customer);
            if (!validationResult.IsValid)
            {
                serviceOutput.Data = customer;
                serviceOutput.Message = "Ocorreram erros na estrutura de validação";
                serviceOutput.Errors = (from x in validationResult.Errors
                                        select new ErrorBase()
                                        {
                                            Message = x.ErrorMessage
                                        }).ToList();
                return serviceOutput;
            }
            var repositoryOutput = await _customerRepository.Update(customer);
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
