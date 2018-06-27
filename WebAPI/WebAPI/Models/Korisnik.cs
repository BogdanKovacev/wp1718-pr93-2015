using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Korisnik
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public PolEnum Pol { get; set; }
        public string Jmbg { get; set; }
        public string KontaktTelefon { get; set; }
        public string Email { get; set; }
        public UlogaEnum Uloga { get; set; }
        public List<Voznja> VoznjeKorisnika { get; set; }
        public bool Blokiran { get; set; }

        public Korisnik()
        {
            VoznjeKorisnika = new List<Voznja>();
        }

        public Korisnik(string korisnickoIme, string lozinka, string ime, string prezime, PolEnum pol, string jmbg, string kontaktTelefon, string email, UlogaEnum uloga, List<Voznja> voznjeKorisnika)
        {
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Pol = pol;
            this.Jmbg = jmbg;
            this.KontaktTelefon = kontaktTelefon;
            this.Email = email;
            this.Uloga = uloga;
            this.VoznjeKorisnika = voznjeKorisnika;
            Blokiran = false;
        }
    }
}