using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjPadaria.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Validade { get; set; }
    }
}
