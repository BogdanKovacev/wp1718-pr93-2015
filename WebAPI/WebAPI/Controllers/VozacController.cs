using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class VozacController : ApiController
    {
        [ResponseType(typeof(void))]
        public IHttpActionResult Post([FromBody]Vozac korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Temp.V = new Vozac(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, UlogaEnum.Vozac, korisnik.VoznjeKorisnika, korisnik.Lokacija, korisnik.Automobil);

            foreach (Vozac musterija in ListaVozaca.Vozaci)
            {
                if (musterija.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                {
                    ListaVozaca.Vozaci.Remove(korisnik);
                    List<Voznja> listaV = musterija.VoznjeKorisnika;
                    Automobil a = new Automobil();
                    foreach(Vozac v in ListaVozaca.Vozaci)
                    {
                        if(v.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                        {
                            a = v.Automobil;
                        }
                    }
                    ListaVozaca.Vozaci.Add(new Vozac(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, UlogaEnum.Vozac, listaV,musterija.Lokacija,a));
                    Temp.V = new Vozac(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, UlogaEnum.Vozac, listaV, musterija.Lokacija, a);

                    /////////////////////// IZMENA VOZACA U BAZI

                    string line = "";

                    foreach (Vozac d in ListaVozaca.Vozaci)
                    {
                        string pol = "";

                        if (d.Pol == PolEnum.Muski)
                        {
                            pol = "Muski";
                        }
                        else
                        {
                            pol = "Zenski";
                        }

                        line += d.KorisnickoIme + "," + d.Lozinka + "," + d.Ime + "," + d.Prezime + "," + pol + "," + d.Jmbg + "," + d.KontaktTelefon + "," + d.Email + "," + d.Lokacija.X + "," + d.Lokacija.Y + "," + d.Lokacija.Adresa + ";";
                    }

                    File.WriteAllText(@"E:\faks\treca\WEB\Projekat\wp1718-pr93-2015\WebAPI\WebAPI\vozaci.txt", line);

                    break;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public Vozac Get()
        {
            return Temp.V;
        }
    }
}
