using RevendaCarros.Domain.Entities;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Repositories
{
    public interface IVeiculoRepository
    {
        IList<Veiculos> GetVendas();
        IList<Veiculos> GetAlugueis();
        IList<Veiculos> GetAll();
    }
}
