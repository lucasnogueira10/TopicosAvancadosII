using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LanchoneteAPI.Model;

namespace LanchoneteAPI.Data
{
    public class LanchoneteAPIContext : DbContext
    {
        public LanchoneteAPIContext (DbContextOptions<LanchoneteAPIContext> options)
            : base(options)
        {
        }

        public DbSet<LanchoneteAPI.Model.Cliente> Cliente { get; set; }

        public DbSet<LanchoneteAPI.Model.Lanche> Lanche { get; set; }

        public DbSet<LanchoneteAPI.Model.Pedido> Pedido { get; set; }
    }
}
