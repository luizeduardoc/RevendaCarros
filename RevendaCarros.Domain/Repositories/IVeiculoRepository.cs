using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using System.Collections.Generic;

namespace RevendaCarros.Domain.Repositories
{
    public interface IVeiculoRepository
    {
        IList<Veiculo> GetVendas();
        IList<Veiculo> GetAlugueis();
        IList<Veiculo> GetAll();
        IList<Veiculo> FindByQuery(VeiculoQueryDto queryFilter);
        Veiculo Create(Veiculo veiculo);
        Veiculo GetById(int id);
        Veiculo UpdateVeiculo(Veiculo veiculo);
    }
}
