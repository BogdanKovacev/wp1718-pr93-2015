using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class VoznjeDispecerController : ApiController
    {
        public List<Voznja> Get()
        {
            List<Voznja> ret = new List<Voznja>();

            foreach (Voznja voznja in Voznje.SveVoznje)
            {
                if (voznja.StatusVoznje == StatusVoznje.Kreirana)
                {
                    ret.Add(voznja);
                }
            }
            return ret;
        }

        public IHttpActionResult Post(FormirajVoznju voznja)
        {
            foreach (Voznja v in Voznje.SveVoznje)
            {
                if (v.LokacijaTaksija.Adresa.Equals(voznja.Adresa))
                {
                    v.Dispecer = Temp.D.KorisnickoIme;
                    v.Vozac = voznja.Vozac;
                    v.StatusVoznje = StatusVoznje.Odradjena;
                    Temp.D.VoznjeKorisnika.Add(v);
                    foreach (Vozac vozac in ListaVozaca.Vozaci)
                    {
                        if (vozac.KorisnickoIme.Equals(voznja.Vozac))
                        {
                            vozac.Slobodan = false;
                            vozac.VoznjeKorisnika.Add(v);
                            return Ok("OK");
                        }
                    }
                }
            }

            return Ok("OK");
        }
    }
}
