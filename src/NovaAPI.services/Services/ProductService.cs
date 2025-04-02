﻿using FluentValidation;
using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Interfaces;
using NovaAPI.Repositories.Repositories;
using NovaAPI.Services.Interfaces.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaAPI.Services.Services
{
    public class ProductService : BaseService<Product, IProductRepository>, IProductService
    {
        private IProductRepository _productRepository => (IProductRepository)_entityRepository;

        public ProductService(IProductRepository productRepository, IValidator<Product> productValidator) : base(productRepository, productValidator)
        {
            //_productRepository = productRepository;
        }

        public async Task<ServiceOutput<Product>> Update(Product product)
        {
            ServiceOutput<Product> serviceOutput = new();
            var validationResult = _entityValidator.Validate(product);
            if (!validationResult.IsValid)
            {
                serviceOutput.Data = product;
                serviceOutput.Message = "Ocorreram erros na estrutura de validação";
                serviceOutput.Errors = (from x in validationResult.Errors
                                        select new ErrorBase()
                                        {
                                            Message = x.ErrorMessage
                                        }).ToList();
                return serviceOutput;
            }
            var repositoryOutput = await _productRepository.Update(product);
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
