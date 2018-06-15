using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Komentar
    {
        string opis;
        DateTime datumObjave;
        Korisnik korisnik;
        Voznja voznja;
        int ocenaVoznje;

        public Komentar(string opis, DateTime datumObjave, Korisnik korisnik, Voznja voznja, int ocenaVoznje)
        {
            this.Opis = opis;
            this.DatumObjave = datumObjave;
            this.Korisnik = korisnik;
            this.Voznja = voznja;
            this.OcenaVoznje = ocenaVoznje;
        }

        public string Opis { get => opis; set => opis = value; }
        public DateTime DatumObjave { get => datumObjave; set => datumObjave = value; }
        public Korisnik Korisnik { get => korisnik; set => korisnik = value; }
        public Voznja Voznja { get => voznja; set => voznja = value; }
        public int OcenaVoznje { get => ocenaVoznje; set => ocenaVoznje = value; }
    }
}