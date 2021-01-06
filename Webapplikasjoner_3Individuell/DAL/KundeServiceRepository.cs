using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Webapplikasjoner_3Individuell.DAL;

namespace Webapplikasjoner_3Individuell
{
    public class KundeServiceRepository : IKundeServiceRepository
    {
        private readonly KundeServiceContext _db;
        private ILogger<KundeServiceRepository> _log;

        public KundeServiceRepository(KundeServiceContext db, ILogger<KundeServiceRepository> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<List<FAQ>> HentAlleFAQ()
        {
            List<FAQ> alleFAQ = await _db.FAQs.ToListAsync();
            return alleFAQ;
        }


        public async Task<List<Kategori>> HentAlleKategorier() 
        {
            List<Kategori> alleKategorier = await _db.Kategorier.ToListAsync();
            return alleKategorier;
        }

        public async Task<bool> Lagre(Kontakt innKontakt)
        {
            try
            {
                var nyKontaktRad = new Kontakt();

                nyKontaktRad.fornavn = innKontakt.fornavn;
                nyKontaktRad.etternavn = innKontakt.etternavn;
                nyKontaktRad.email = innKontakt.email;
                nyKontaktRad.telefon = innKontakt.telefon;
                nyKontaktRad.melding = innKontakt.melding;

                _db.kontaktskjema.Add(nyKontaktRad);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }

        public async Task<List<Kontakt>> HentAlleKontakter()
        {
            List<Kontakt> alleKontakter = await _db.kontaktskjema.ToListAsync();
            return alleKontakter;
        }

        public async Task<Kontakt> HentEnKontakt(int kId)
        {
            Kontakt enKontakt = await _db.kontaktskjema.FindAsync(kId);
            var hentetKontakt = new Kontakt()
            {
                kId = enKontakt.kId,
                fornavn = enKontakt.fornavn,
                etternavn = enKontakt.etternavn,
                email = enKontakt.email,
                telefon = enKontakt.telefon,
                melding = enKontakt.melding
            };
            return hentetKontakt;
        }

        public async Task<bool> Ja(int id)
        {
            try
            {
                var stemme = _db.FAQs.FirstOrDefault(s => s.id == id);
                stemme.jaStemme += 1;
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Nei(int id)
        {
            try
            {
                var stemme = _db.FAQs.FirstOrDefault(s => s.id == id);
                stemme.neiStemme += 1;
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}



