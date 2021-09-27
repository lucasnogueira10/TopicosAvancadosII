using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LanchoneteAPI.Model;

namespace LanchoneteWebApp.Data
{
    public class LanchoneteWebAppContext : DbContext
    {
        public LanchoneteWebAppContext (DbContextOptions<LanchoneteWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<LanchoneteAPI.Model.Cliente> Cliente { get; set; }

        public DbSet<LanchoneteAPI.Model.Lanche> Lanche { get; set; }

        public DbSet<LanchoneteAPI.Model.Pedido> Pedido { get; set; }
    }
}
