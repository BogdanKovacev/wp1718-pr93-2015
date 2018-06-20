using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class MusterijaZahtevController : ApiController
    {
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(Vozac korisnik)
        {
            Voznja voznja = new Voznja(DateTime.Now, korisnik.Lokacija, korisnik.Automobil.TipAutomobila, Temp.M.KorisnickoIme, null, "", "", -1, null, StatusVoznje.Kreirana);

            foreach (Musterija musterija in ListaMusterija.Musterije)
            {
                if (musterija.KorisnickoIme.Equals(Temp.M.KorisnickoIme))
                {
                    musterija.VoznjeKorisnika.Add(voznja);
                    Voznje.SveVoznje.Add(voznja);
                    return Ok(musterija);
                }
            }

            return BadRequest("GRESKA");
        }

        public Vozac Get()
        {
            return Temp.V;
        }
    }
}
