namespace RevendaCarros.Domain.Dtos
{
    public class VeiculoQueryDto
    {
        public bool? ArCondicionado { get; set; }
        public bool? Automatico { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Number { get; set; }
        public int? Take { get; set; }
    }
}
