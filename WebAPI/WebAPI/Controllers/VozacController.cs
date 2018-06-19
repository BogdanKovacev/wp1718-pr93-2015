using System;
using System.Collections.Generic;
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

            Temp.V = new Vozac(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, korisnik.Uloga, korisnik.VoznjeKorisnika, korisnik.Lokacija, korisnik.Automobil);

            foreach (Vozac musterija in ListaVozaca.Vozaci)
            {
                if (musterija.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                {
                    ListaVozaca.Vozaci.Remove(korisnik);
                    List<Voznja> listaV = musterija.VoznjeKorisnika;
                    ListaVozaca.Vozaci.Add(new Vozac(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, UlogaEnum.Musterija, listaV,musterija.Lokacija,musterija.Automobil));
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
