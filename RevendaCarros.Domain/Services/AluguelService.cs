using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using RevendaCarros.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Services
{
    public class AluguelService : IAluguelService
    {
        private readonly IAluguelRepository repository;
        private readonly IVeiculoRepository veiculoRepository;

        public AluguelService(IAluguelRepository repository, IVeiculoRepository veiculoRepository)
        {
            this.repository = repository;
            this.veiculoRepository = veiculoRepository;
        }

        public IList<Aluguel> GetAll()
        {
            var result = repository.GetAll();
            return result;
        }

        public Aluguel Create(AluguelDto aluguelDto)
        {
            var veiculo = veiculoRepository.GetById(aluguelDto.IdVeiculo);
            if(veiculo.TipoOperacao.Equals("Aluguel") && veiculo.Disponivel)
            {
                var result = repository.CreateAluguel(aluguelDto);
                veiculo.ChangeDisponibilidade();
                veiculoRepository.UpdateVeiculo(veiculo);
                return result;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public Veiculo DevolveVeiculo(string placa)
        {
            var veiculo = veiculoRepository.GetByPlaca(placa);
            veiculo.ChangeDisponibilidade();
            var result = veiculoRepository.UpdateVeiculo(veiculo);

            return result;
        }
    }
}