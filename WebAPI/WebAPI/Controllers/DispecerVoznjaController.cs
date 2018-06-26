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
    public class DispecerVoznjaController : ApiController
    {
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(TempVoznja voznja)
        {
            TipVozilaEnum tipVozila = TipVozilaEnum.Podrazumevani;
            Lokacija odrediste = new Models.Lokacija();
            string x = odrediste.Random();
            string y = odrediste.Random();
            odrediste.Adresa = voznja.LokacijaTaksija; //NIJE LOKACIJA TAKSIJA NEGO ODREDISTE

            Vozac tempVozac = null;

            foreach(Vozac v in ListaVozaca.Vozaci)
            {
                if(v.KorisnickoIme.Equals(voznja.Vozac))
                {
                    tempVozac = v; // VOZAC
                }
            }

            if(tempVozac == null)
            {
                return BadRequest("Trenutno nema slobodnih vozaca.");
            }

            if(voznja.TipVozila.Equals("Putnicki"))
            {
                tipVozila = TipVozilaEnum.Putnicki;
            }
            else if (voznja.TipVozila.Equals("Kombi"))
            {
                tipVozila = TipVozilaEnum.Kombi;
            }
            else if (voznja.TipVozila.Equals("Podrazumevani"))
            {
                tipVozila = TipVozilaEnum.Podrazumevani;
            }

            Voznja voz = new Voznja(DateTime.UtcNow,odrediste,tipVozila, "",odrediste,Temp.D.KorisnickoIme,voznja.Vozac,0,new Komentar(),StatusVoznje.Formirana);

            Voznje.SveVoznje.Add(voz);

            foreach (Vozac v in ListaVozaca.Vozaci)
            {
                if (v.KorisnickoIme.Equals(voznja.Vozac))
                {
                    v.VoznjeKorisnika.Add(voz);
                }
            }

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

            return StatusCode(HttpStatusCode.NoContent);
        }

        public List<Vozac> Get()
        {
            List<Vozac> ret = new List<Vozac>();

            foreach(Vozac v in ListaVozaca.Vozaci)
            {
                if(v.Slobodan)
                {
                    ret.Add(v);
                }
            }

            return ret;
        }
    }
}
