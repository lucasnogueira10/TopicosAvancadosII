using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public virtual Livro Livro { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> Livros { get; set; }

        [DisplayName("Data de Empréstimo")]
        public DateTime DtEmprestimo { get; set; }

        [DisplayName("Data de Devolução")]
        public DateTime DtDevolucao { get; set; }

        public virtual Cliente Cliente { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> Clientes { get; set; }
    }
}
