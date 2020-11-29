using RevendaCarros.Domain.Enums;

namespace RevendaCarros.Domain.Dtos
{
    public class EstoqueDto
    {
        public EstoqueDto(string placa,
                          string cor,
                          double preco,
                          string tipoVeiculo,
                          string tipoOperacao,
                          bool arCondicionado,
                          bool automatico)
        {
            Placa = placa;
            Cor = cor;
            Preco = preco;
            TipoVeiculo = tipoVeiculo;
            TipoOperacao = tipoOperacao;
            ArCondicionado = arCondicionado;
            Automatico = automatico;
        }

        public string Placa { get; set; }
        public string Cor { get; set; }
        public double Preco { get; set; }
        public string TipoVeiculo { get; set; }
        public string TipoOperacao { get; set; }
        public bool ArCondicionado { get; set; }
        public bool Automatico { get; set; }
    }
}
