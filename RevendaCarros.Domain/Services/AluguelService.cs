using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using RevendaCarros.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Services
{
    public class AluguelService : IAluguelService
    {
        private readonly IAluguelaRepository repository;

        public AluguelService(IAluguelaRepository repository)
        {
            this.repository = repository;
        }

        public IList<Aluguel> GetAll()
        {
            var result = repository.GetAll();
            return result;
        }

        public Aluguel Create(AluguelDto aluguelDto)
        {
            var result = repository.Create(aluguelDto);
            return result;
        }
    }
}