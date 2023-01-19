using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvaPedidoEletronico.Models
{
    public class Resultado
    {
        public string Valor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AnoModelo { get; set; }
        public string Combustivel { get; set; }
        public string CodigoFipe { get; set; }
        public string MesReferencia { get; set; }
        public string TipoVeiculo { get; set; }
        public string SiglaCombustivel { get; set; }
    }
}