using System;
using Paella.Application.Persistence;
using Paella.Domain.Entities;

namespace Paella.Application.OrderUseCases.GetById
{
    public class GetByIdUseCase : IGetByIdUseCase
    {
        private readonly IOrderRepository _repository;

        public GetByIdUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Order Execute(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}