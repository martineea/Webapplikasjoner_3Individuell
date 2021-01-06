using System;
using System.Diagnostics.CodeAnalysis;

namespace Webapplikasjoner_3Individuell.Models
{
    public class FAQ
    {
        public int id { get; set; }
        public string sporsmal { get; set; }
        public string svar { get; set; }
        public int jaStemme { get; set; }
        public int neiStemme { get; set; }
        public string kategori { get; set; }
    }
}
