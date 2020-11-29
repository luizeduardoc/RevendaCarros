using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using RevendaCarros.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository repository;

        public VendaService(IVendaRepository repository)
        {
            this.repository = repository;
        }

        public IList<Venda> GetAll()
        {
            var result = repository.GetAll();
            return result;
        }

        public Venda Create(VendaDto vendaDto)
        {
            var novaVenda = new Venda(vendaDto.IdVeiculo, vendaDto.Valor, vendaDto.NomeComprador);
            var result = repository.Insert(novaVenda);

            return result;
        }
    }
}
