using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaCarros.Domain.Entities
{
    [Table("alugueis")]
    public class Alugueis : IEntity
    {
        public Alugueis(int IdVeiculo, double ValorMensal, string Nome, DateTime DataRetirada, DateTime DataDevolucao)
        {
            this.IdVeiculo = IdVeiculo;
            this.ValorMensal = ValorMensal;
            this.Nome = Nome;
            this.DataRetirada = DataRetirada;
            this.DataDevolucao = DataDevolucao;
        }

        public Veiculos Veiculo { get; set; }
        public int Id { get; set; }
        public int IdVeiculo { get; set; }
        public double ValorMensal { get; set; }
        public string Nome { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataRetirada { get; set; }
    }
}

