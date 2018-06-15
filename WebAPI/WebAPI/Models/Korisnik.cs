using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Korisnik
    {
        string korisnickoIme;
        string lozinka;
        string ime;
        string prezime;
        PolEnum pol;
        string jmbg;
        string kontaktTelefon;
        string email;
        UlogaEnum uloga;
        List<Voznja> voznjeKorisnika;

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
        }

        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public PolEnum Pol { get => pol; set => pol = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public string KontaktTelefon { get => kontaktTelefon; set => kontaktTelefon = value; }
        public string Email { get => email; set => email = value; }
        public UlogaEnum Uloga { get => uloga; set => uloga = value; }
        public List<Voznja> VoznjeKorisnika { get => voznjeKorisnika; set => voznjeKorisnika = value; }
    }
}