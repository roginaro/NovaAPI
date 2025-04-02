using FluentValidation;
using NovaAPI.Entities.Base;
using NovaAPI.Entities.Models;
using NovaAPI.Repositories.Interfaces;
using NovaAPI.Repositories.Repositories;
using NovaAPI.Services.Interfaces.Materials;

namespace NovaAPI.Services.Services
{
    public abstract class BaseService<T> : IService<T> where T : class
    {
        public readonly IRepository<T> _entityRepository;
        public readonly IValidator<T> _entityValidator;

        public BaseService(IRepository<T> entityRepository, IValidator<T> entityValidator)
        {
            _entityRepository = entityRepository;
            _entityValidator = entityValidator;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entityRepository.GetAll();
        }

        public async Task<ServiceOutput<T>> Add(T entity)
        {
            ServiceOutput<T> serviceOutput = new();
            var validationResult = _entityValidator.Validate(entity);
            if (!validationResult.IsValid)
            {
                serviceOutput.Data = entity;
                serviceOutput.Message = "Ocorreram erros na estrutura de validação";
                serviceOutput.Errors = (from x in validationResult.Errors
                                        select new ErrorBase()
                                        {
                                            Message = x.ErrorMessage
                                        }).ToList();
                return serviceOutput;
            }
            var repositoryOutput = await _entityRepository.Add(entity);
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

        public async Task<ServiceOutput<T>> Delete(int id)
        {
            ServiceOutput<T> serviceOutput = new();
            var repositoryOutput = await _entityRepository.Remove(id);
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

        public async Task<ServiceOutput<T>> Get(int id)
        {
            ServiceOutput<T> serviceOutput = new();
            var repositoryOutput = await _entityRepository.GetById(id);
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
