using System;
using System.Collections.Generic;
using System.IO;
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
            else if (komentar.TipVozila.Equals("Cetiri"))
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
                if (voznja.StatusVoznje.Equals(StatusVoznje.Kreirana) || voznja.StatusVoznje.Equals(StatusVoznje.Formirana))
                {
                    Temp.V.Slobodan = true;
                    voznja.StatusVoznje = StatusVoznje.Neuspesna;
                    retKom.Voznja = voznja.Datum;
                    voznja.Komentar = retKom;
                    voznja.Iznos = -1;

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

            //////////////////////////// DODAJ KOMENTAR U BAZI VOZNJI

            string line = "";

            foreach (Voznja d in Voznje.SveVoznje)
            {
                string tipVozilaVoznja = "";

                if (d.TipVozila == TipVozilaEnum.Putnicki)
                {
                    tipVozilaVoznja = "Putnicki";
                }
                else if (d.TipVozila == TipVozilaEnum.Kombi)
                {
                    tipVozilaVoznja = "Kombi";
                }
                else
                {
                    tipVozilaVoznja = "Podrazumevani";
                }

                line += d.Datum.ToString() + "," + d.LokacijaTaksija.X + "," + d.LokacijaTaksija.Y + "," + d.LokacijaTaksija.Adresa + "," + tipVozilaVoznja + "," + d.Musterija + "," + d.Odrediste.X + "," + d.Odrediste.Y + "," + d.Odrediste.Adresa + "," + d.Dispecer + "," + d.Vozac + "," + d.Iznos + "," + d.Komentar.Opis + "," + d.Komentar.DatumObjave + "," + d.Komentar.Korisnik + "," + d.Komentar.Voznja + "," + d.Komentar.OcenaVoznje + "," + d.StatusVoznje.ToString() + ";";
            }

            File.WriteAllText(@"E:\faks\treca\WEB\Projekat\wp1718-pr93-2015\WebAPI\WebAPI\voznje.txt", line);

            return Ok("Uspesno");
        }
    }
}
