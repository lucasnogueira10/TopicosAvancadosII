using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjPadaria.Model
{
    public class Padaria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string QtdFuncionarios { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
