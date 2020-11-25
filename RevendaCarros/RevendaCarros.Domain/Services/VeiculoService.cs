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

        public IList<EstoqueDto> GetVendas()
        {
            var result = repository.GetVendas();
            var novoEstoque = result.Select(x => new EstoqueDto(x.Placa,
                                                                x.Cor,
                                                                x.Preco,
                                                                Enum.GetName(typeof(TipoVeiculo), x.TipoVeiculo),
                                                                x.TipoOperacao)).ToList();

            return novoEstoque;
        }

        public IList<EstoqueDto> GetAlugueis()
        {
            var result = repository.GetAlugueis();
            var novoEstoque = result.Select(x => new EstoqueDto(x.Placa,
                                                                x.Cor,
                                                                x.Preco,
                                                                Enum.GetName(typeof(TipoVeiculo), x.TipoVeiculo),
                                                                x.TipoOperacao)).ToList();

            return novoEstoque;
        }

        public IList<EstoqueDto> GetAll()
        {
            var result = repository.GetAll();
            var novoEstoque = result.Select(x => new EstoqueDto(x.Placa,
                                                                x.Cor,
                                                                x.Preco,
                                                                Enum.GetName(typeof(TipoVeiculo), x.TipoVeiculo),
                                                                x.TipoOperacao)).ToList();

            return novoEstoque;
        }
    }
}
