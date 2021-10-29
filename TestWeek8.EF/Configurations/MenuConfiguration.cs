using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek8.Core.Models;

namespace TestWeek8.EF.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                .IsRequired();

            builder
                .HasMany(m => m.Piatti)
                .WithOne(p => p.Menu);

            builder.HasData(
                new Menu
                {
                    Id = 1,
                    Nome = "Menu di Capodanno"
                },
                new Menu
                {
                    Id = 2,
                    Nome = "Menu di Natale"
                },
                new Menu
                {
                    Id = 3,
                    Nome = "Menu di Pasqua"
                }
            );
        }
    }
}
