using System;

namespace RevendaCarros.Domain.Dtos
{
    public class AluguelDto
    {
        public int IdVeiculo { get; set; }
        public double Valor { get; set; }
        public string NomeComprador { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
