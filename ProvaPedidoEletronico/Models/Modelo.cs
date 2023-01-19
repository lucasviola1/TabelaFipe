using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvaPedidoEletronico.Models
{

    public class ModeloNames {
        public List<Modelo> modelos { get; set; }

        public List<Modelo> anos { get; set; }
    }
    public class Modelo
    {
        public string nome { get; set; }
        public string codigo { get; set; }
    }
}