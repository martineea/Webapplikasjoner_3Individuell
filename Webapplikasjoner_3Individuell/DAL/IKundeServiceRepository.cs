using System.Collections.Generic;
using System.Threading.Tasks;
using Webapplikasjoner_3Individuell.DAL;

namespace Webapplikasjoner_3Individuell
{
    public interface IKundeServiceRepository
    {
        Task<List<FAQ>> HentAlleFAQ();
        Task<List<Kontakt>> HentAlleKontakter();
        Task<List<Kategori>> HentAlleKategorier();
        Task<bool> Lagre(Kontakt innKontakt);
        Task<bool> Ja(int id);
        Task<bool> Nei(int id);
    }
}