using RevendaCarros.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaCarros.Domain.Entities
{
    [Table("veiculos")]
    public class Veiculo : IEntity
    {
        public Veiculo(string placa,
                       string cor,
                       double preco,
                       bool arCondicionado,
                       bool automatico,
                       string marca,
                       string modelo,
                       TipoVeiculo tipoVeiculo,
                       string tipoOperacao)
        {
            Placa = placa;
            Cor = cor;
            Preco = preco;
            ArCondicionado = arCondicionado;
            Automatico = automatico;
            Marca = marca;
            Modelo = modelo;
            TipoVeiculo = tipoVeiculo;
            TipoOperacao = tipoOperacao;
            Disponivel = true;
        }

        public int Id { get; private set; }
        public string Placa { get; private set; }
        public string Cor { get; private set; }
        public double Preco { get; private set; }
        public bool ArCondicionado { get; private set; }
        public bool Automatico { get; private set; }
        public bool Disponivel { get; set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public TipoVeiculo TipoVeiculo { get; private set; }
        public string TipoOperacao { get; private set; }        
        public Venda Venda { get; private set; }
        public Aluguel Aluguel { get; set; }

        public void ChangeDisponibilidade()
        {
            Disponivel = !Disponivel;
        }
    }
}
