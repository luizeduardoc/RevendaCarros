using RevendaCarros.Domain.Entities;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Repositories
{
    public interface IVeiculoRepository
    {
        IList<Veiculos> GetAll();
    }
}
