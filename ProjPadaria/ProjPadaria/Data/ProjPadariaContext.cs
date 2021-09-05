using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjPadaria.Model;

namespace ProjPadaria.Data
{
    public class ProjPadariaContext : DbContext
    {
        public ProjPadariaContext (DbContextOptions<ProjPadariaContext> options)
            : base(options)
        {
        }

        public DbSet<ProjPadaria.Model.Padaria> Padaria { get; set; }

        public DbSet<ProjPadaria.Model.Produto> Produto { get; set; }

        public DbSet<ProjPadaria.Model.Cliente> Cliente { get; set; }
    }
}
