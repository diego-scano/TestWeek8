using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek8.Core.Models;
using TestWeek8.EF.Configurations;

namespace TestWeek8.EF
{
    public class MainContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Piatto> Piatti { get; set; }
        public DbSet<Utente> Utenti { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new PiattoConfiguration());
            modelBuilder.ApplyConfiguration(new UtenteConfiguration());
        }
    }
}
