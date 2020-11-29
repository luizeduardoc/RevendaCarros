using RevendaCarros.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaCarros.Domain.Entities
{
    [Table("veiculos")]
    public class Veiculo : IEntity
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public double Preco { get; set; }
        public bool ArCondicionado { get; set; }
        public bool Automatico { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public string TipoOperacao { get; set; }        
        public Venda Venda { get; set; }
    }
}
