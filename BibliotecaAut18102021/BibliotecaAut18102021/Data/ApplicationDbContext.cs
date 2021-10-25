using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Models;

namespace BibliotecaComAutenticacao.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Teste.Models.Autor> Autor { get; set; }
        public DbSet<Teste.Models.Cliente> Cliente { get; set; }
        public DbSet<Teste.Models.Status> Status { get; set; }
        public DbSet<Teste.Models.Livro> Livro { get; set; }
        public DbSet<Teste.Models.Emprestimo> Emprestimo { get; set; }
    }
}
