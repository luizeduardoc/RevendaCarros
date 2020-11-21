using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaCarros.Domain.Entities
{
    [Table("alugueis")]
    public class Alugueis : IEntity
    {
        public int IdCarro { get; set; }
        public double ValorMensal { get; set; }
        public string Nome { get; set; }
        public DatabaseGeneratedAttribute DataDevolucao { get; set; } //data (?)
        public DatabaseGeneratedAttribute DataRetirada { get; set; } //data (?)
    }
}

