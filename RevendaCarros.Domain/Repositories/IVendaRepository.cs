using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Repositories
{
    public interface IVendaRepository : IRepository<Venda>
    {
        IList<Venda> GetAll();
        Venda Create(VendaDto vendaDto);
    }
}