using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskWebApp.Models;

namespace MegaDeskWebApp.Data
{
    public class MegaDeskWebAppContext : DbContext
    {
        public MegaDeskWebAppContext (DbContextOptions<MegaDeskWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<DeskQuote> DeskQuotes { get; set; }
        public DbSet<Desk> Desks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeskQuote>().ToTable("DeskQuote");
            modelBuilder.Entity<Desk>().ToTable("Desk");
        }

    }
}
