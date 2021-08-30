using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMVCDotNetCore.Models
{
    public class Fornecedor
    {
        #region Properties

        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }

        #endregion
    }
}
