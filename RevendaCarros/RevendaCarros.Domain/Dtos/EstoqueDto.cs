using RevendaCarros.Domain.Enums;

namespace RevendaCarros.Domain.Dtos
{
    public class EstoqueDto
    {
        public EstoqueDto(string placa,
                          string cor,
                          double preco,
                          string tipoVeiculo,
                          string tipoOperacao)
        {
            Placa = placa;
            Cor = cor;
            Preco = preco;
            TipoVeiculo = tipoVeiculo;
            TipoOperacao = tipoOperacao;
        }

        public string Placa { get; set; }
        public string Cor { get; set; }
        public double Preco { get; set; }
        public string TipoVeiculo { get; set; }
        public string TipoOperacao { get; set; }
    }
}
