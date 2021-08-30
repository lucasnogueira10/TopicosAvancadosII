using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjMVCDotNetCore.Models;

namespace ProjMVCDotNetCore.Data
{
    public class ProjMVCDotNetCoreContext : DbContext
    {
        public ProjMVCDotNetCoreContext (DbContextOptions<ProjMVCDotNetCoreContext> options)
            : base(options)
        {
        }

        public DbSet<ProjMVCDotNetCore.Models.Fornecedor> Fornecedor { get; set; }

        public DbSet<ProjMVCDotNetCore.Models.Funcionario> Funcionario { get; set; }

        public DbSet<ProjMVCDotNetCore.Models.Produto> Produto { get; set; }
    }
}
