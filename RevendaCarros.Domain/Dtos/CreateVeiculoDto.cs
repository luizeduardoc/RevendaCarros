using RevendaCarros.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevendaCarros.Domain.Dtos
{
    public class CreateVeiculoDto
    {        
        public string Placa { get; set; }
        public string Cor { get; set; }
        public double Preco { get; set; }
        public bool ArCondicionado { get; set; }
        public bool Automatico { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public string TipoOperacao { get; set; }        
    }
}
