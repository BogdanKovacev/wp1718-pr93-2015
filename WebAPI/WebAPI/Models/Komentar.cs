using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Komentar
    {
        public string Opis { get; set; }
        public DateTime DatumObjave { get; set; }
        public Korisnik Korisnik { get; set; }
        public Voznja Voznja { get; set; }
        public int OcenaVoznje { get; set; }

        public Komentar(string opis, DateTime datumObjave, Korisnik korisnik, Voznja voznja, int ocenaVoznje)
        {
            this.Opis = opis;
            this.DatumObjave = datumObjave;
            this.Korisnik = korisnik;
            this.Voznja = voznja;
            this.OcenaVoznje = ocenaVoznje;
        }
        
    }
}