using LibraryManager.Infrastructure.Core;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RevendaCarros.Infrastructure.Repositories
{
    public class VeiculoRepository : Repository<Veiculos>, IVeiculoRepository
    {
        public VeiculoRepository(RevendaCarrosContext context)
            : base(context)
        {
        }

        public IList<Veiculos> GetVendas()
        {            
            return Query().Where(x => x.TipoOperacao.Equals("Venda")).ToList();
        }

        public IList<Veiculos> GetAlugueis()
        {
            return Query().Where(x => x.TipoOperacao.Equals("Aluguel")).ToList();
        }

        public IList<Veiculos> GetAll()
        {
            return Query().ToList();
        }
    }
}
