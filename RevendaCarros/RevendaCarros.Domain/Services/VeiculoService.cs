using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Enums;
using RevendaCarros.Domain.Repositories;
using RevendaCarros.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RevendaCarros.Domain.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository repository;

        public VeiculoService(IVeiculoRepository repository)
        {
            this.repository = repository;
        }

        public IList<EstoqueDto> GetAll()
        {
            var result = repository.GetAll();
            var novoEstoque = result.Select(e => new EstoqueDto
            {
                Cor = e.Cor,
                Placa = e.Placa,
                Preco = e.Preco,
                VeiculoTipo = Enum.GetName(typeof(TipoVeiculo), e.TipoVeiculo)
            }).ToList();

            return novoEstoque;
        }
    }
}
