using System.Collections.Generic;
using RevendaCarros.Domain.Entities;

namespace RevendaCarros.Domain.Services.Interfaces
{
    public interface IVendaService
    {
        IList<Vendas> GetAll();
    }
}
