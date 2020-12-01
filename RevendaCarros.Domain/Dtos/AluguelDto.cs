using System;

namespace RevendaCarros.Domain.Dtos
{
    public class AluguelDto
    {
        public int IdVeiculo { get; set; }         
        public double ValorMensal { get; set; }
        public string Nome { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataRetirada { get; set; }
    }
}