using RevendaCarros.Domain.Entities;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Repositories
{
    public interface IVeiculoRepository
    {
        IList<Veiculo> GetVendas();
        IList<Veiculo> GetAlugueis();
        IList<Veiculo> GetAll();
    }
}
