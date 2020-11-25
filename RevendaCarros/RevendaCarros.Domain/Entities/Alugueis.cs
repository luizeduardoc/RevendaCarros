using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaCarros.Domain.Entities
{
    [Table("alugueis")]
    public class Alugueis : IEntity
    {
        public int Id { get; set; }
        public int IdCarro { get; set; }
        public double ValorMensal { get; set; }
        public string Nome { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataRetirada { get; set; }
    }
}

