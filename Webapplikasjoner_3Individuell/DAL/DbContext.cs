using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Webapplikasjoner_3Individuell.Models;

namespace Webapplikasjoner_3Individuell.DAL
{

    public class FAQ
    {
        [Key]
        public int id { get; set; }
        public string sporsmal { get; set; }
        public string svar { get; set; }
        public int jaStemme { get; set; }
        public int neiStemme { get; set; }
        public string kategori { get; set; }
    }

    public class Kontakt
    {
        [Key]
        public int kId { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public string melding { get; set; }
    }

    public class Kategori
    {
        [Key]
        public int kaId { get; set; }
        public string kategoriNavn { get; set; }
    }


    public class KundeServiceContext : DbContext
    {
        public KundeServiceContext(DbContextOptions<KundeServiceContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<FAQ> FAQs { get; set; }
        public virtual DbSet<Kontakt> kontaktskjema { get; set; }
        public virtual DbSet<Kategori> Kategorier { get; set; }

        // legge til"viritual" på de attriuttene som ønskes å lastes automatisk (LazyLoading)

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
