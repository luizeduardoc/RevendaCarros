using RevendaCarros.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaCarros.Domain.Entities
{
    [Table("veiculos")]
    public class Veiculos : IEntity
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public double Preco { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public string TipoOperacao { get; set; }        
        public Vendas Venda { get; set; }
    }
}
