using System;
using System.ComponentModel.DataAnnotations;

namespace Webapplikasjoner_3Individuell.Models
{
    public class Kontakt
    {
        public int kId { get; set; }
        [RegularExpression (@"[a-zæøåA-ZÆØÅ]{2,20}")]
        public string fornavn { get; set; }
        [RegularExpression(@"[a-zæøåA-ZÆØÅ]{2,20}")]
        public string etternavn { get; set; }
        [RegularExpression(@"[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}")]
        public string email { get; set; }
        [RegularExpression(@"[0-9]{8}")]
        public string telefon { get; set; }
        public string melding { get; set; }
    }
}

