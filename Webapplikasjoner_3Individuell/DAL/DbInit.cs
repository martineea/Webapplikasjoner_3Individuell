using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webapplikasjoner_3Individuell.Models;

namespace Webapplikasjoner_3Individuell.DAL
{
    public class DbInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<KundeServiceContext>();

                // må slette og opprette databasen hver gang når den skal initieres (seedes)
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                /*---------Oppretter Kategorier--------*/

                var billettinfo = new Kategori { kategoriNavn = "Billettinfo" };
                var førAvgang = new Kategori { kategoriNavn = "Før avgang" };
                var påBussen = new Kategori { kategoriNavn = "På bussen" };

                context.Kategorier.Add(billettinfo);
                context.Kategorier.Add(førAvgang);
                context.Kategorier.Add(påBussen);

                /*---------Oppretter Spørsmål og svar--------*/
                
                var FAQ1 = new FAQ {
                    sporsmal = "Hvordan reiser man med Nor-Way i korona-tiden?",
                    svar = "Følg siste råd for reise i forbindelse med Korona-virus" +
                    "Vi oppfordrer alle til å følge råd for hvordan man omgås med-reisende og egen håndhygiene. " +
                    "Hold avstand til dine med-passasjerer og sjåføren. " +
                    "Vask hendene godt og bruk håndsprit der det er tilgjengelig. " +
                    "Ikke dra ut på reise om du kjenner forkjølelsessymptomer. " +
                    "Kjøp billett på forhånd slik at kontanthåndtering og kortbruk i buss ikke er nødvendig.",
                    kategori = "Før avgang",
                    jaStemme = 2,
                    neiStemme = 0

                };

                var FAQ2 = new FAQ {
                    sporsmal = "Hvordan vise fram billetten på bussen?",
                    svar = "Dokument med strekkode / referansenummer må medbringes under hele reisen - enten digitalt " +
                    "eller på papir. Du som kunde må selv sørge for at strekkode eller referansenummer ikke kommer på avveie. " +
                    "Dersom andre benytter seg av disse, vil billetten bli registrert som benyttet og bli ugyldig for deg.",
                    kategori = "På bussen",
                    jaStemme = 2,
                    neiStemme = 0
                };

                var FAQ3 = new FAQ {
                    sporsmal = "Kan jeg endre billetten/ bestillingen min?",
                    svar = "Billetten du har kjøpt kan ikke endres, men kjøpssum vil refunderes ved avbestilling senest 24 " +
                    "timer før første avgangstid på billetten. For refusjon, se spørsmål om: Hvordan få refusjon for billettene" +
                    "mine?",
                    kategori = "Billettinfo",
                    jaStemme = 3,
                    neiStemme = 1
                };
                
                var FAQ4 = new FAQ
                {
                    sporsmal = "Hvilke billettyper har dere?",
                    svar = "Det finnes to ulike typer billetter. Barnebillett og voksenbillett. Barn under 3 år reiser gratis. " +
                    "Studenter og honører kan gå under barnebillett.",
                    kategori = "Billettinfo",
                    jaStemme = 5,
                    neiStemme = 1
                };

                var FAQ5 = new FAQ
                {
                    sporsmal = "Kan jeg legge til en passasjer til på bestillingen min?",
                    svar = "For å legge til flere passasjerer til bestillingen din må du kontakte Nor-Ways kundeservice." +
                    "Ring 22 31 31 50. Åpningstider: Man-Fre: kl.08.00-19.00, lørdag: kl.09.00-15.00. Søndag og " +
                    "helligdager: stengt.",
                    kategori = "Billettinfo",
                    jaStemme = 1,
                    neiStemme = 1
                };

               var FAQ6 = new FAQ
                {
                    sporsmal = "Når må man møte opp før avgang?",
                    svar = "Møt opp i god tid. For at bussen ikke skal kjøre fra deg, er det viktig at du møter opp på " +
                    "holdeplassen i god tid før avgangstidspunkt. På de fleste større bussterminaler og rutebilstasjoner " +
                    "har du mulighet for å gå om bord i bussen 10–15 minutter før avgang.",
                   kategori = "Før avgang",
                   jaStemme = 0,
                   neiStemme = 0
               };

                var FAQ7 = new FAQ
                {
                    sporsmal = "Hvor mye bagasje kan man medbringe?",
                    svar = "Du får legge 2 kolli bagasje (maks 30 kg) gratis i bussens bagasjerom. Inn i bussen kan du ta med " +
                    "håndveske/liten sekk med verdisaker og det du trenger til reisen. Dette plasseres ved føttene dine. " +
                    "Trillekofferter må pga plassbegrensning og sikkerhet legges i bagasjerom. ",
                    kategori = "Før avgang",
                    jaStemme = 1,
                    neiStemme = 0
                };

                 var FAQ8 = new FAQ
                {
                    sporsmal = "Kan man reise med handicap eller rullestol?",
                    svar = "Er du rullestolbruker med behov for egen plass til rullestolen din om bord på bussen, må vi be om " +
                    "at du reserverer plass senest kl. 14:00 siste hverdag før reisen. Ta kontakt med kundeservice.",
                     kategori = "Før avgang",
                     jaStemme = 0,
                     neiStemme = 0
                 };

                var FAQ9 = new FAQ
                {
                    sporsmal = "Kan man ta med dyr på bussen?",
                    svar = "Kun førerhund, tjenestehund og servicehund i tjeneste eller opplæring som kan identifiseres med " +
                    "vest og/eller skriftlig dokumentasjon er tillatt på våre busser, og reiser gratis. Utover dette er det " +
                    "dessverre ikke tillatt med dyr om bord i våre ekspressbusser. Unntak på Flybussen linje FB2: Hunder, katter og " +
                    "andre mindre kjæledyr kan tas med på Flybussen uten ekstra kostnader. ",
                    kategori = "Før avgang",
                    jaStemme = 0,
                    neiStemme = 0
                };

                var FAQ10 = new FAQ
                {
                    sporsmal = "Hvordan få refusjon for billettene mine?",
                    svar = "Refusjon gis inntil 24 timer før avgang. Dersom du fyller ut og sender inn refusjonskjemaet " +
                    "(sendt som vedlegg på pdf sammen med billetten din) senest 24 timer før første avreisetidspunkt.",
                    kategori = "Billettinfo",
                    jaStemme = 6,
                    neiStemme = 2
                };

                var FAQ11 = new FAQ
                {
                    sporsmal = "Får man servert/ kjøpt mat eller drikke på bussen?",
                    svar = "Du får dessverre ikke servert mat på bussen. Det er tilgang til å kjøpe vann, kaffe/ te og mineralvann på " +
                    "alle våre busser",
                    kategori = "På bussen",
                    jaStemme = 2,
                    neiStemme = 0
                };

                var FAQ12 = new FAQ
                {
                    sporsmal = "Har man tilgang til pute/ dyne på bussen?",
                    svar = "Vi har puter og dyner til utlån, samt pakker med sovemaske og ørepropper til salgs.",
                    kategori = "På bussen",
                    jaStemme = 7,
                    neiStemme = 1
                };

                var FAQ13 = new FAQ
                {
                    sporsmal = "Hvilke fasiliteter er det på bussen?",
                    svar = "Du kan lene deg tilbake, slappe av og nyte utsikten i våre komfortable seter med nedfellbar rygg, fothviler " +
                    "og ekstra god plass til beina. Klimaanlegg sørger for at det er behagelig temperatur og frisk luft, uansett årstid. " +
                    "Våre busser har også toaletter, gratis Wi-Fi og 220 volts strømuttak",
                    kategori = "På bussen",
                    jaStemme = 0,
                    neiStemme = 0
                };

                context.FAQs.Add(FAQ1);
                context.FAQs.Add(FAQ2);
                context.FAQs.Add(FAQ3);
                context.FAQs.Add(FAQ4);
                context.FAQs.Add(FAQ5);
                context.FAQs.Add(FAQ6);
                context.FAQs.Add(FAQ7);
                context.FAQs.Add(FAQ8);
                context.FAQs.Add(FAQ9);
                context.FAQs.Add(FAQ10);
                context.FAQs.Add(FAQ11);
                context.FAQs.Add(FAQ12);
                context.FAQs.Add(FAQ13);

                /*---------Oppretter et brukerspørsmål og svar--------*/

                var kontakt1 = new Kontakt {
                    melding = "Hei, kan man ta med seg spedbarn på bussen?" };

                context.kontaktskjema.Add(kontakt1);

                context.SaveChanges();

            }
        }
    }
}
