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
    public class Komentar2Controller : ApiController
    {
        public IHttpActionResult Post(Komentar komentar)
        {
            Komentar retKom = new Komentar(komentar.Opis, DateTime.Now, Temp.M.KorisnickoIme, DateTime.Now, komentar.OcenaVoznje);
            List<Voznja> temp = new List<Voznja>();
            int index = int.Parse(komentar.Korisnik);

            foreach (Voznja voznja in Temp.M.VoznjeKorisnika)
            {
                temp.Add(voznja);
            }
            retKom.Voznja = temp[index].Datum;

            Voznje.SveVoznje.Remove(temp[index]);
            Temp.M.VoznjeKorisnika.Remove(temp[index]);
            temp[index].Komentar = retKom;
            temp[index].Pomoc = 0;

            Voznje.SveVoznje.Add(temp[index]);
            Temp.M.VoznjeKorisnika.Add(temp[index]);

            ////////////////////////////// IZMENI VOZNJU (DODAJ KOMENTAR)

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
