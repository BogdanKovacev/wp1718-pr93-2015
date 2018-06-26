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
                    v.StatusVoznje = StatusVoznje.Kreirana;
                    Temp.D.VoznjeKorisnika.Add(v);
                    foreach (Vozac vozac in ListaVozaca.Vozaci)
                    {
                        if (vozac.KorisnickoIme.Equals(voznja.Vozac))
                        {
                            vozac.Slobodan = false;
                            vozac.VoznjeKorisnika.Add(v);

                            //////////// IZMENI VOZNJU U BAZI

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

                            return Ok("OK");
                        }
                    }
                }
            }

            return Ok("OK");
        }
    }
}
