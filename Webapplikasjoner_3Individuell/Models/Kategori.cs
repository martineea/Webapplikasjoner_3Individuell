using System;
using System.ComponentModel.DataAnnotations;

namespace Webapplikasjoner_3Individuell.Models
{
    public class Kategori
    {
        [Key]
        public int kaId { get; set; }
        public string kategoriNavn { get; set; }
    }
}
