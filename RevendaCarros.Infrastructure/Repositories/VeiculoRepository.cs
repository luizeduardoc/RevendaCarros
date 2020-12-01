using RevendaCarros.Domain.Dtos;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using System;
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
            return Query().Where(x => x.TipoOperacao.Equals("Venda")).Where(x => x.Disponivel == true).ToList();
        }

        public IList<Veiculo> GetAlugueis()
        {
            return Query().Where(x => x.TipoOperacao.Equals("Aluguel")).Where(x => x.Disponivel == true).ToList();
        }

        public IList<Veiculo> GetAll()
        {
            return Query().ToList();
        }

        public IList<Veiculo> FindByQuery(VeiculoQueryDto queryFilter)
        {
            if(queryFilter is null)
            {
                return new List<Veiculo>();
            }

            var query = Query();

            if(queryFilter.Take.HasValue)
            {
                var skip = ((queryFilter.Number - 1) * queryFilter.Take.Value);
                query = Query().Skip(skip).Take(queryFilter.Take.Value);
            }

            if(queryFilter.ArCondicionado.HasValue)
            {
                query = query.Where(v => v.ArCondicionado.Equals(queryFilter.ArCondicionado));
            }

            if(queryFilter.Automatico.HasValue)
            {
                query = query.Where(v => v.Automatico.Equals(queryFilter.Automatico));
            }

            if (!String.IsNullOrEmpty(queryFilter.Cor))
            {
                query = query.Where(v => v.Cor.Equals(queryFilter.Cor));
            }

            if (!String.IsNullOrEmpty(queryFilter.Modelo))
            {
                query = query.Where(v => v.Modelo.Equals(queryFilter.Modelo));
            }

            if (!String.IsNullOrEmpty(queryFilter.Marca))
            {
                query = query.Where(v => v.Marca.Equals(queryFilter.Marca));
            }              

            return query.ToList();
        }

        public Veiculo Create(Veiculo veiculo)
        {
            var result = Insert(veiculo);
            return result;
        }

        public Veiculo GetById(int id)
        {
            var result = Query().Where(v => v.Id == id).FirstOrDefault();
            return result;
        }

        public Veiculo UpdateVeiculo(Veiculo veiculo)
        {
            var result = Update(veiculo);
            return result;
        }
    }
}
