using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste.Models;

namespace BibliotecaWebApp.Data
{
    public class BibliotecaWebAppContext : DbContext
    {
        public BibliotecaWebAppContext (DbContextOptions<BibliotecaWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Teste.Models.Autor> Autor { get; set; }

        public DbSet<Teste.Models.Status> Status { get; set; }

        public DbSet<Teste.Models.Cliente> Cliente { get; set; }

        public DbSet<Teste.Models.Livro> Livro { get; set; }

        public DbSet<Teste.Models.Emprestimo> Emprestimo { get; set; }
    }
}
