using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string codTurma { get; set; }

        public string Semestre { get; set; }

        public string Ano { get; set; }

        public virtual Professor Professor { get; set; }

        public virtual Aluno Aluno { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> Professors { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> Alunoes { get; set; }

    }
}
