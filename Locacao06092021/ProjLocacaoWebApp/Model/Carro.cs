using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjCarros.Model
{
    public class Carro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public int Modelo { get; set; }
        public string Placa { get; set; }
    }

}
