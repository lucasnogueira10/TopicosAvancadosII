using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMVCDotNetCore.Models
{
    public class Funcionario
    {
        #region Properties

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        #endregion
    }
}
