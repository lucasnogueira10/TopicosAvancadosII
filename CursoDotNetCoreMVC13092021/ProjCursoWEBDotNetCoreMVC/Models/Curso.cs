using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CursoWebCoreMVC.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public virtual Aluno Aluno { get; set; }
        [NotMapped]
        public virtual List<SelectListItem> Alunos { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        [NotMapped]
        public virtual List<SelectListItem> Disciplinas { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
