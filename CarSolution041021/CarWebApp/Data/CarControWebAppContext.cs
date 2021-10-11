using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarControWebApp.Models;

namespace CarControWebApp.Data
{
    public class CarControWebAppContext : DbContext
    {
        public CarControWebAppContext (DbContextOptions<CarControWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<CarControWebApp.Models.Car> Car { get; set; }
    }
}
