using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMVCDotNetCore.Models
{
    public class Produto
    {
        #region Properties

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public string DtCadastro { get; set; }

        #endregion
    }
}
