using System.ComponentModel.DataAnnotations.Schema;

namespace RevendaCarros.Domain.Entities
{
    [Table("impostos")]
    public class Impostos : IEntity
    {
        public int Id { get; set; }
        public double Valor { get; set; }
    }
}
