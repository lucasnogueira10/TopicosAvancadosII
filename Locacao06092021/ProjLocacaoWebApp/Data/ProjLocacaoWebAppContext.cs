using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjCarros.Model;

namespace ProjLocacaoWebApp.Data
{
    public class ProjLocacaoWebAppContext : DbContext
    {
        public ProjLocacaoWebAppContext (DbContextOptions<ProjLocacaoWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<ProjCarros.Model.Carro> Carro { get; set; }

        public DbSet<ProjCarros.Model.Locacao> Locacao { get; set; }
    }
}
