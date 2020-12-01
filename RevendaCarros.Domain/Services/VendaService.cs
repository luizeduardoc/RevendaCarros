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
        private readonly IImpostoRepository impostoRepository;

        public VendaService(IVendaRepository repository, IImpostoRepository impostoRepository)
        {
            this.repository = repository;
            this.impostoRepository = impostoRepository;
        }

        public IList<Venda> GetAll()
        {
            var result = repository.GetAll();
            return result;
        }

        public Venda Create(VendaDto vendaDto)
        {
            var result = repository.Create(vendaDto);
            var imposto = 0.0;
            if(result.Valor > 300000.00)
            {
                imposto = impostoRepository.Get("ImpostoAltoValor").Valor;
            }
            else
            {
                imposto = impostoRepository.Get("ImpostoBaixoValor").Valor;
            }
            
            result.AddValor(imposto);
            return result;
        }
    }
}
