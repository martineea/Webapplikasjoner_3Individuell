using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Webapplikasjoner_3Individuell.DAL;

//[HttpPost] : Lagre en.
//[HttpGet]  :  Hent alle.
//[HttpGet("{id}")] : Hent en med Id.
//[HttpPut] : Endre en.
//[HttpDelete("{id}")] : Slett en med Id.

namespace Webapplikasjoner_3Individuell.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FAQController : ControllerBase
    {
        private readonly IKundeServiceRepository _db;
        private readonly ILogger<FAQController> _log;

        public FAQController(IKundeServiceRepository db, ILogger<FAQController> log)
        {
            _db = db;
            _log = log;
        }

        [HttpGet("hentFAQ")]
        public async Task<ActionResult> HentAlleFAQ()
        {
            List<FAQ> alleFAQ = await _db.HentAlleFAQ();
            return Ok(alleFAQ);
        }

        [HttpGet("kategorier")]
        public async Task<ActionResult> HentAlleKategorier()
        {
            List<Kategori> alleKategorier = await _db.HentAlleKategorier();
            return Ok(alleKategorier);
        }

        [HttpPost("lagre")]
        public async Task<ActionResult> Lagre(Kontakt innKontakt)
        {
            if (ModelState.IsValid)
            {
                bool returOK = await _db.Lagre(innKontakt);
                if (!returOK)
                {
                    _log.LogInformation("Kontaktskjema ble ikke sendt");
                    return BadRequest("Kontaktskjema ble ikke sendt");
                }
                return Ok("Kontaktskjema ble mottat");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        [HttpGet("hentKontakter")]
        public async Task<ActionResult> HentAlleKontakter()
        {
            List<Kontakt> alleKontakter = await _db.HentAlleKontakter();
            return Ok(alleKontakter);
        }

        [HttpPost("ja")]
        public async Task<ActionResult> Ja([FromBody] int id)
        {
            bool returOK = await _db.Ja(id);
            if (!returOK)
            {
                _log.LogInformation("Vurdering ble ikke registrert");
                return BadRequest();
            }
            return Ok("Vurdering ble registrert");
        }

        [HttpPost("nei")]
        public async Task<ActionResult> Nei([FromBody] int id)
        {
            bool returOK = await _db.Nei(id);
            if (!returOK)
            {
                _log.LogInformation("Vurdering ble ikke registrert");
                return BadRequest();
            }
            return Ok("Vurdering ble registrert");
        }
    }
}