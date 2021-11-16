using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoAPI.Model
{
    public class Turma
    {
        public int Id { get; set; }
        public string codTurma { get; set; }

        public string Semestre { get; set; }

        public string Ano { get; set; }

        public Professor Professor { get; set; }

        public Aluno Aluno { get; set; }
    }
}
