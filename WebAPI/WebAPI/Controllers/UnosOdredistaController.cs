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
    public class UnosOdredistaController : ApiController
    {
        public IHttpActionResult Post(FormirajVoznju voznja)
        {
            foreach (Voznja v in Temp.V.VoznjeKorisnika)
            {
                if (v.StatusVoznje.Equals(StatusVoznje.Formirana) || v.StatusVoznje.Equals(StatusVoznje.Kreirana) || v.StatusVoznje.Equals(StatusVoznje.Prihvacena))
                {
                    v.Iznos = double.Parse(voznja.Iznos);
                    v.Odrediste = new Lokacija();
                    v.Odrediste.Adresa = voznja.Adresa;
                    v.StatusVoznje = StatusVoznje.Uspesna;

                    foreach (Vozac vozac in ListaVozaca.Vozaci)
                    {
                        if (vozac.KorisnickoIme.Equals(Temp.V.KorisnickoIme))
                            vozac.Slobodan = true;
                    }

                    foreach (Voznja v1 in Voznje.SveVoznje)
                    {
                        if (v1.LokacijaTaksija.Adresa.Equals(v.LokacijaTaksija.Adresa))
                        {
                            v1.Iznos = double.Parse(voznja.Iznos);
                            v1.Odrediste.Adresa = voznja.Adresa;
                            v1.StatusVoznje = StatusVoznje.Uspesna;
                            v1.Pomoc = 1;

                            //////////////////////// IZMENI VOZNJU U BAZI

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

                        }
                    }

                    foreach (Voznja v2 in Temp.D.VoznjeKorisnika)
                    {
                        if (v2.LokacijaTaksija.Adresa.Equals(v.LokacijaTaksija.Adresa))
                        {
                            v2.Iznos = double.Parse(voznja.Iznos);
                            v2.Odrediste.Adresa = voznja.Adresa;
                            v2.StatusVoznje = StatusVoznje.Uspesna;
                        }
                    }

                    /*foreach (Voznja v3 in UlogovaniKorisnici.Musterija.Voznje)
                    {
                        if (v3.LokacijaNaKojuTaksiDolazi.Adresa.Ulica.Equals(v.LokacijaNaKojuTaksiDolazi.Adresa.Ulica) && v3.LokacijaNaKojuTaksiDolazi.Adresa.Broj == v.LokacijaNaKojuTaksiDolazi.Adresa.Broj)
                        {
                            v3.Iznos = double.Parse(voznja.Iznos);
                            v3.Odrediste.Adresa.Broj = int.Parse(voznja.Broj);
                            v3.Odrediste.Adresa.Ulica = voznja.Ulica;
                            v3.StatusVoznje = StatusVoznje.Uspesna;
                        }
                    }*/
                }
            }

            return Ok();
        }
    }
}
