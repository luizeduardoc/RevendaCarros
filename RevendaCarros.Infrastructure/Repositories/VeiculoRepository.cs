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
            return Query().Where(x => x.Disponivel).ToList();
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

        public Veiculo Create(CreateVeiculoDto veiculo)
        {
            var novoVeiculo = new Veiculo(veiculo.Placa,
                                          veiculo.Cor,
                                          veiculo.Preco,
                                          veiculo.ArCondicionado,
                                          veiculo.Automatico,
                                          veiculo.Marca,
                                          veiculo.Modelo,
                                          veiculo.TipoVeiculo,
                                          veiculo.TipoOperacao);

            var result = Insert(novoVeiculo);
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
        public Veiculo GetByPlaca(string placa)
        {
            var veiculo = Query().Where(v => v.Placa.Equals(placa)).FirstOrDefault();
            return veiculo;
        }
    }
}
