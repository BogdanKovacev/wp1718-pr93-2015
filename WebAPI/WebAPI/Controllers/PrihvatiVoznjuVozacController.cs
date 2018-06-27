using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PrihvatiVoznjuVozacController : ApiController
    {
        public IHttpActionResult Post(FormirajVoznju voznja)
        {
            if (Temp.V.Slobodan)
            {
                foreach (Voznja v in Voznje.SveVoznje)
                {
                    if (v.LokacijaTaksija.Adresa.Equals(voznja.Adresa))
                    {
                        v.Vozac = Temp.V.KorisnickoIme;
                        v.StatusVoznje = StatusVoznje.Prihvacena;
                        Temp.V.VoznjeKorisnika.Add(v);
                        Temp.V.Slobodan = false;
                    }
                }
                return Ok("OK");
            }
            else
            {
                return BadRequest("ERROR: Trenutno ste zauzeti!");
            }
        }
    }
}
