using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaCarros.Domain.Entities
{
    [Table("alugueis")]
    public class Aluguel : IEntity
    {
        public Aluguel(int idVeiculo,
                       double valorMensal,
                       string nome,
                       DateTime dataEntrega,
                       DateTime dataRetirada)
        {
            IdVeiculo = idVeiculo;
            ValorMensal = valorMensal;
            Nome = nome;
            DataEntrega = dataEntrega;
            DataRetirada = dataRetirada;
        }

        public int Id { get; set; }
        public int IdVeiculo { get; set; }
        public double ValorMensal { get; set; }
        public string Nome { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataRetirada { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}

