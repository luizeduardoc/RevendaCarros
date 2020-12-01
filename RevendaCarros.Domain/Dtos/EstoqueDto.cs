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
                          bool automatico,
                          string marca,
                          string modelo,
                          bool disponivel)
        {
            Placa = placa;
            Cor = cor;
            Preco = preco;
            TipoVeiculo = tipoVeiculo;
            TipoOperacao = tipoOperacao;
            ArCondicionado = arCondicionado;
            Automatico = automatico;
            Marca = marca;
            Modelo = modelo;
            Disponivel = disponivel;
        }

        public string Placa { get; set; }
        public string Cor { get; set; }
        public double Preco { get; set; }
        public string TipoVeiculo { get; set; }
        public string TipoOperacao { get; set; }
        public bool ArCondicionado { get; set; }
        public bool Automatico { get; set; }
        public string Marca { get; set; }
        public bool Disponivel { get; set; }
        public string Modelo { get; set; }
    }
}
