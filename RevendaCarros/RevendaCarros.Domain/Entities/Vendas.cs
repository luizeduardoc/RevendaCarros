using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaCarros.Domain.Entities
{
    [Table("vendass")]
    public class Vendas : IEntity
    {
        public int IdCarro { get; set; }
        public double Valor { get; set; }
        public string NomeComprador { get; set; }
    }
}
