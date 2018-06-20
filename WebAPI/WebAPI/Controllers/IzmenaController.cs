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
    public class IzmenaController : ApiController
    {
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(TempLokacija korisnik)
        {
            string temp = korisnik.KorisnickoImeVozaca;
            string k = korisnik.Lokacija2; // ulogovani korisnik za koga se menja voznja
            Voznja tempVoznja = null;
            List<Voznja> lista = new List<Voznja>();
            string opcija = temp.Substring(0,6);

            string[] i = temp.Split('_');

            int index = Int32.Parse(i[1]);

            if(opcija.Equals("obrisi"))
            {
                foreach(Voznja voz in Temp.M.VoznjeKorisnika)
                {
                    if(voz.StatusVoznje.Equals(StatusVoznje.Kreirana))
                    {
                        lista.Add(voz);
                    }
                }

                tempVoznja = lista[index];

                foreach (Voznja voz in Temp.M.VoznjeKorisnika)
                {
                    if (tempVoznja.Datum.Equals(voz.Datum))
                    {
                        voz.StatusVoznje = StatusVoznje.Otkazana;
                        foreach (Voznja voz1 in Voznje.SveVoznje)
                        {
                            if (tempVoznja.Datum.Equals(voz1.Datum))
                            {
                                voz1.StatusVoznje = StatusVoznje.Otkazana;
                            }
                        }
                    }
                }

            }

            return StatusCode(HttpStatusCode.NoContent);

        }
    }
}
