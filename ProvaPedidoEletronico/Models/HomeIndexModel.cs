using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvaPedidoEletronico.Models
{
    public class HomeIndexModel
    {
        public IEnumerable<Ano> ano { get; set; }
        public IEnumerable<Marca> marca { get; set; }
        public ModeloNames modelo{ get; set; }
        public Resultado resultado { get; set; }

    }
}