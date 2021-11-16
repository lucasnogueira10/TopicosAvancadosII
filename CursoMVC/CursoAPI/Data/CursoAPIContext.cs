using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CursoAPI.Model;

namespace CursoAPI.Data
{
    public class CursoAPIContext : DbContext
    {
        public CursoAPIContext (DbContextOptions<CursoAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CursoAPI.Model.Aluno> Aluno { get; set; }

        public DbSet<CursoAPI.Model.Professor> Professor { get; set; }

        public DbSet<CursoAPI.Model.Curso> Curso { get; set; }

        public DbSet<CursoAPI.Model.Turma> Turma { get; set; }
    }
}
