using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Vozac : Korisnik
    {
        public Lokacija Lokacija { get; set; }
        public Automobil Automobil { get; set; }
        public bool Slobodan { get; set; }

        public Vozac(string korisnickoIme, string lozinka, string ime, string prezime, PolEnum pol, string jmbg, string kontaktTelefon, string email, UlogaEnum uloga, List<Voznja> voznjeKorisnika, Lokacija lokacija, Automobil automobil) : base(korisnickoIme, lozinka, ime, prezime, pol, jmbg, kontaktTelefon, email, uloga, voznjeKorisnika)
        {
            this.Lokacija = lokacija;
            this.Automobil = automobil;
            Slobodan = true;
        }

        public Vozac()
        {
            Lokacija = new Lokacija();
            Automobil = new Automobil();
            VoznjeKorisnika = new List<Voznja>();
        }

    }
}