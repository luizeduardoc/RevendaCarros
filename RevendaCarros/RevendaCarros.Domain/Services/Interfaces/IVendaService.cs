using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Services.Interfaces
{
    public interface IVendaService
    {
        IList<Venda> GetAll();
        Venda Create(VendaDto vendaDto);
    }
}
