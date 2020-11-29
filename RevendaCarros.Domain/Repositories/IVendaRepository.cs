using System;
using System.Collections.Generic;
using LibraryManager.Domain.Repositories.Core;
using RevendaCarros.Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace RevendaCarros.Domain.Repositories
{
    public interface IVendaRepository : IRepository<Venda>
    {
        IList<Venda> GetAll();
    }
}