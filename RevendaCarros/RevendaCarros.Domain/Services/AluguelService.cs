using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using RevendaCarros.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Services
{
    public class AluguelService : IAluguelService
    {
        private readonly IAluguelRepository repository;

        public AluguelService(IAluguelRepository repository)
        {
            this.repository = repository;
        }

        public IList<Alugueis> GetAll()
        {
            var result = repository.GetAll();
            return result;
        }

        public Alugueis Create(AluguelDto aluguelDto)
        {
            var novoAluguel = new Alugueis(aluguelDto.IdVeiculo, aluguelDto.Valor, aluguelDto.NomeComprador, aluguelDto.DataRetirada, aluguelDto.DataEntrega);
            var result = repository.Insert(novoAluguel);

            return result;
        }
    }
}