using System.Collections.Generic;
using LibraryManager.Domain.Repositories.Core;
using RevendaCarros.Domain.Entities;

namespace RevendaCarros.Domain.Repositories
{
    public interface IVendaRepository : IRepository<Vendas>
    {
        IList<Vendas> GetAll();
    }
}