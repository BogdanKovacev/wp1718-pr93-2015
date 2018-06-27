using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class KorisniciController : ApiController
    {
        public List<Korisnik> Get()
        {
            List<Korisnik> ret = new List<Korisnik>();

            foreach (Musterija musterija in ListaMusterija.Musterije)
            {
                ret.Add(musterija);
            }

            foreach (Vozac vozac in ListaVozaca.Vozaci)
            {
                ret.Add(vozac);
            }

            return ret;
        }

        public IHttpActionResult Post(FormirajVoznju korisnik)
        {
            List<Korisnik> ret = new List<Korisnik>();

            foreach (Musterija musterija in ListaMusterija.Musterije)
            {
                ret.Add(musterija);
            }

            foreach (Vozac vozac in ListaVozaca.Vozaci)
            {
                ret.Add(vozac);
            }

            ret[int.Parse(korisnik.Iznos)].Blokiran = !ret[int.Parse(korisnik.Iznos)].Blokiran;

            if (ret[int.Parse(korisnik.Iznos)].Blokiran)
            {
                return Ok("INFO: Uspesno ste blokirali korisika " + ret[int.Parse(korisnik.Iznos)].KorisnickoIme.ToString() + ".");
            }
            else
            {
                return Ok("INFO: Uspesno ste aktivirali korisika " + ret[int.Parse(korisnik.Iznos)].KorisnickoIme.ToString() + ".");
            }
        }
    }
}
