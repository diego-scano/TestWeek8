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
    public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.Ruolo)
                .IsRequired()
                .HasConversion(
                    r => r.ToString(),
                    r => (Ruolo)Enum.Parse(typeof(Ruolo), r));

            builder.HasData(
                new Utente
                {
                    Id = 1,
                    Email = "diego.scano@abc.it",
                    Password = "1234",
                    Ruolo = Ruolo.Ristoratore
                },
                new Utente
                {
                    Id = 2,
                    Email = "mario.rossi@abc.it",
                    Password = "5678",
                    Ruolo = Ruolo.Cliente
                }
            );
        }
    }
}
