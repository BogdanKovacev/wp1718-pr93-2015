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
    public class DispecerController : ApiController
    {
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(Korisnik korisnik)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Temp.D = new Dispecer(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, korisnik.Uloga, korisnik.VoznjeKorisnika);

            foreach (Dispecer musterija in ListaDispecera.Dispeceri)
            {
                if (musterija.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                {
                    ListaDispecera.Dispeceri.Remove(musterija);
                    List<Voznja> listaV = musterija.VoznjeKorisnika;
                    ListaDispecera.Dispeceri.Add(new Dispecer(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, UlogaEnum.Musterija, listaV));
                    break;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public Dispecer Get()
        {
            return Temp.D;
        }
    }
}
