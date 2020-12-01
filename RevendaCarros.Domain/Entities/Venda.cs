using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaCarros.Domain.Entities
{
    [Table("vendas")]
    public class Venda : IEntity
    {
        public Venda(int idVeiculo, double valor, string nomeComprador)
        {
            IdVeiculo = idVeiculo;
            Valor = valor;
            NomeComprador = nomeComprador;
        }

        public int Id { get; set; }
        public double Valor { get; private set; }
        public string NomeComprador { get; set; }
        [ForeignKey("id_veiculo")]
        public int IdVeiculo { get; set; }
        public Veiculo Veiculo { get; set; }

        public double AddValor(double valor)
        {
            Valor += valor;
            return Valor;
        }

    }
}
