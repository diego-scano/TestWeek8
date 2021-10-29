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
    public class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired();

            builder.Property(p => p.Tipo)
                .IsRequired()
                .HasConversion(
                    t => t.ToString(),
                    t => (Tipologia)Enum.Parse(typeof(Tipologia), t));

            builder.Property(p => p.Prezzo)
                .IsRequired();

            builder.Property(p => p.MenuId);

            builder
                .HasOne(p => p.Menu)
                .WithMany(m => m.Piatti)
                .HasForeignKey(p => p.MenuId);

            builder.HasData(
                new Piatto
                {
                    Id = 1,
                    Nome = "Tortelloni di ricotta ed erbe di campo",
                    Tipo = Tipologia.Primo,
                    Prezzo = 9.90M,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 2,
                    Nome = "Lasagne ai funghi",
                    Tipo = Tipologia.Primo,
                    Prezzo = 11,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 3,
                    Nome = "Stinco di maiale al forno",
                    Tipo = Tipologia.Secondo,
                    Prezzo = 11.5M,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 4,
                    Nome = "Spiedini di gamberi al cumino",
                    Tipo = Tipologia.Secondo,
                    Prezzo = 12,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 5,
                    Nome = "Verza all'aceto",
                    Tipo = Tipologia.Contorno,
                    Prezzo = 6.5M,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 6,
                    Nome = "Funghi champignon al forno",
                    Tipo = Tipologia.Contorno,
                    Prezzo = 7,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 7,
                    Nome = "Meringhe al cacao e alla nocciola",
                    Tipo = Tipologia.Dolce,
                    Prezzo = 5.9M,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 8,
                    Nome = "Zuppa inglese",
                    Tipo = Tipologia.Dolce,
                    Prezzo = 4,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 9,
                    Nome = "Anelletti al forno",
                    Tipo = Tipologia.Primo,
                    Prezzo = 10,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 10,
                    Nome = "Crespelle al nero di seppia e salmone",
                    Tipo = Tipologia.Primo,
                    Prezzo = 11.5M,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 11,
                    Nome = "Gamberoni al forno",
                    Tipo = Tipologia.Secondo,
                    Prezzo = 11.9M,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 12,
                    Nome = "Rollatine di pollo alla Wellington",
                    Tipo = Tipologia.Secondo,
                    Prezzo = 9M,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 13,
                    Nome = "Zucca al forno con arancia e pepe",
                    Tipo = Tipologia.Contorno,
                    Prezzo = 7,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 14,
                    Nome = "Patate ventaglio al forno",
                    Tipo = Tipologia.Contorno,
                    Prezzo = 5,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 15,
                    Nome = "Cassata al forno",
                    Tipo = Tipologia.Dolce,
                    Prezzo = 5.5M,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 16,
                    Nome = "Babà napoletano",
                    Tipo = Tipologia.Dolce,
                    Prezzo = 6,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 17,
                    Nome = "Tagliolini al ragù di agnello",
                    Tipo = Tipologia.Primo,
                    Prezzo = 11.9M,
                    MenuId = 3
                },
                new Piatto
                {
                    Id = 18,
                    Nome = "Pasta al forno con funghi, prosciutto e piselli",
                    Tipo = Tipologia.Primo,
                    Prezzo = 10.9M,
                    MenuId = 3
                },
                new Piatto
                {
                    Id = 19,
                    Nome = "Costine di agnello al sugo",
                    Tipo = Tipologia.Secondo,
                    Prezzo = 13,
                    MenuId = 3
                },
                new Piatto
                {
                    Id = 20,
                    Nome = "Anelli di calamari al forno",
                    Tipo = Tipologia.Secondo,
                    Prezzo = 13.5M,
                    MenuId = 3
                },
                new Piatto
                {
                    Id = 21,
                    Nome = "Cavoletti di bruxelles arrosto con salsa di sesamo e limone",
                    Tipo = Tipologia.Contorno,
                    Prezzo = 7.9M,
                    MenuId = 3
                },
                new Piatto
                {
                    Id = 22,
                    Nome = "Rotolo al cocco con crema di cioccolato",
                    Tipo = Tipologia.Dolce,
                    Prezzo = 8.5M,
                    MenuId = 3
                },
                new Piatto
                {
                    Id = 23,
                    Nome = "Crostatine con chantilly al torrone",
                    Tipo = Tipologia.Dolce,
                    Prezzo = 6.9M,
                    MenuId = 3
                }
            );
        }
    }
}
