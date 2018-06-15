using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Dispecer : Korisnik
    {

        public Dispecer(string korisnickoIme, string lozinka, string ime, string prezime, PolEnum pol, string jmbg, string kontaktTelefon, string email, UlogaEnum uloga, List<Voznja> voznjeKorisnika) : base(korisnickoIme, lozinka, ime, prezime, pol, jmbg, kontaktTelefon, email, uloga, voznjeKorisnika)
        {
        }
    }
}