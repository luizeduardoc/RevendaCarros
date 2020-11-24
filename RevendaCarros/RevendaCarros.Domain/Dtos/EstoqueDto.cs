using RevendaCarros.Domain.Enums;

namespace RevendaCarros.Domain.Dtos
{
    public class EstoqueDto
    {
        public string Placa { get; set; }
        public string Cor { get; set; }
        public double Preco { get; set; }
        public string VeiculoTipo { get; set; }
    }
}
