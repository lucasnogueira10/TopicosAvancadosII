using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string codCurso { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public virtual Turma Turma { get; set; }
        
        [NotMapped]
        public virtual List<SelectListItem> Turmas { get; set; }
    }
}
