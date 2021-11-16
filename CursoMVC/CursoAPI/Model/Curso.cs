using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoAPI.Model
{
    public class Curso
    {
        public int Id { get; set; }
        public string codCurso { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public Turma Turma { get; set; }
    }
}
