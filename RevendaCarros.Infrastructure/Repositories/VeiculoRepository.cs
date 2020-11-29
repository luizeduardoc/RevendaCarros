using LibraryManager.Infrastructure.Core;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RevendaCarros.Infrastructure.Repositories
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(RevendaCarrosContext context)
            : base(context)
        {
        }

        public IList<Veiculo> GetVendas()
        {            
            return Query().Where(x => x.TipoOperacao.Equals("Venda")).ToList();
        }

        public IList<Veiculo> GetAlugueis()
        {
            return Query().Where(x => x.TipoOperacao.Equals("Aluguel")).ToList();
        }

        public IList<Veiculo> GetAll()
        {
            return Query().ToList();
        }
    }
}
