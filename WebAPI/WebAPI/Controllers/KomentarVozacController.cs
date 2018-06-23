using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class KomentarVozacController : ApiController
    {
        public IHttpActionResult Post(TempVoznja komentar)
        {
            int ocenaTemp = 0;

            if (komentar.TipVozila.Equals("Nula"))
            {
                ocenaTemp = 0;
            }
            else if (komentar.TipVozila.Equals("Jedan"))
            {
                ocenaTemp = 1;
            }
            else if (komentar.TipVozila.Equals("Dva"))
            {
                ocenaTemp = 2;
            }
            else if (komentar.TipVozila.Equals("Tri"))
            {
                ocenaTemp = 3;
            }
            else if (komentar.TipVozila.Equals("Cetri"))
            {
                ocenaTemp = 4;
            }
            else if (komentar.TipVozila.Equals("Pet"))
            {
                ocenaTemp = 5;
            }

            Komentar retKom = new Komentar(komentar.LokacijaTaksija, DateTime.Now, Temp.V.KorisnickoIme, DateTime.Now, ocenaTemp);

            foreach (Voznja voznja in Temp.V.VoznjeKorisnika)
            {
                if (voznja.StatusVoznje.Equals(StatusVoznje.Odradjena) || voznja.StatusVoznje.Equals(StatusVoznje.Formirana))
                {
                    Temp.V.Slobodan = true;
                    voznja.StatusVoznje = StatusVoznje.Neuspesna;
                    retKom.Voznja = voznja.Datum;
                    voznja.Komentar = retKom;

                    foreach (Voznja v in Voznje.SveVoznje)
                    {
                        if (v.LokacijaTaksija.Adresa.Equals(voznja.LokacijaTaksija.Adresa))
                        {
                            v.StatusVoznje = StatusVoznje.Neuspesna;
                            v.Komentar = retKom;
                        }
                    }

                    foreach (Voznja v1 in Temp.D.VoznjeKorisnika)
                    {
                        if (v1.LokacijaTaksija.Adresa.Equals(voznja.LokacijaTaksija.Adresa))
                        {
                            v1.StatusVoznje = StatusVoznje.Neuspesna;
                            v1.Komentar = retKom;
                        }
                    }

                    foreach (Voznja v2 in Temp.M.VoznjeKorisnika)
                    {
                        if (v2.LokacijaTaksija.Adresa.Equals(voznja.LokacijaTaksija.Adresa))
                        {
                            v2.StatusVoznje = StatusVoznje.Neuspesna;
                            v2.Komentar = retKom;
                        }
                    }
                }
            }

            return Ok("Uspesno");
        }
    }
}
