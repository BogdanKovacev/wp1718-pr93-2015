using System;
using System.Collections.Generic;
using System.IO;
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
            string adresa = korisnik.Lokacija.Adresa;

            string[] tempAdresa = adresa.Split(',');

            Voznja voznja = new Voznja();

            if(tempAdresa.Count() > 3)
            {
                //45.255277560019785,19.836160105959834,Pavla Papa 42, Novi Sad 21000, Serbia
                Lokacija l = new Lokacija(tempAdresa[0],tempAdresa[1],tempAdresa[2] + "," + tempAdresa[3]);
                voznja = new Voznja(DateTime.Now, l,korisnik.Automobil.TipAutomobila,Temp.M.KorisnickoIme,l,"","",-1,new Komentar(),StatusVoznje.Kreirana);
            }
            else
            {
                Lokacija l = new Lokacija();
                voznja = new Voznja(DateTime.Now, korisnik.Lokacija, korisnik.Automobil.TipAutomobila, Temp.M.KorisnickoIme, new Lokacija(l.Random(), l.Random(), korisnik.Lokacija.Adresa), "", "", -1, new Komentar(), StatusVoznje.Kreirana);
            }

            

            foreach (Musterija musterija in ListaMusterija.Musterije)
            {
                if (musterija.KorisnickoIme.Equals(Temp.M.KorisnickoIme))
                {
                    musterija.VoznjeKorisnika.Add(voznja);
                    Voznje.SveVoznje.Add(voznja);

                    //////////////////////////////// DODAJ VOZNJU U BAZU

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
