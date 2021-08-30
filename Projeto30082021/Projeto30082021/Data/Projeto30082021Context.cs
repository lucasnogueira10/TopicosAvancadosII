using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto30082021.Model;

namespace Projeto30082021.Data
{
    public class Projeto30082021Context : DbContext
    {
        public Projeto30082021Context (DbContextOptions<Projeto30082021Context> options)
            : base(options)
        {
        }

        public DbSet<Projeto30082021.Model.Person> Person { get; set; }
    }
}
