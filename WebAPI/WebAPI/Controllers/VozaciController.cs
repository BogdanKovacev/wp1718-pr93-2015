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
    public class VozaciController : ApiController
    {
        public List<Vozac> Get()
        {
            List<Vozac> ret = new List<Vozac>();

            foreach (Vozac vozac in ListaVozaca.Vozaci)
            {
                if (vozac.Slobodan)
                    ret.Add(vozac);
            }

            return ret;
        }

        [ResponseType(typeof(Vozac))]
        public IHttpActionResult Post(FormirajVoznju voznja)
        {
            Lokacija l = new Lokacija("", "", voznja.Adresa);
            Voznja v = new Voznja(DateTime.Now, l, voznja.ZeljeniTipAutomobila, "", null, Temp.D.KorisnickoIme, voznja.Vozac, -1, null, StatusVoznje.Formirana);
            Temp.D.VoznjeKorisnika.Add(v);
            Voznje.SveVoznje.Add(v);

            foreach (Vozac vozac in ListaVozaca.Vozaci)
            {
                if (vozac.KorisnickoIme.Equals(voznja.Vozac))
                {
                    vozac.Slobodan = false;
                    vozac.VoznjeKorisnika.Add(v);
                    return Ok(vozac);
                }
            }
            return Ok(v);
        }
    }
}
