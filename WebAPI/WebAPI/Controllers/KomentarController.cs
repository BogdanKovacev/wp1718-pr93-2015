using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class KomentarController : ApiController
    {
        public IHttpActionResult Post(TempLokacija komentar)
        {
            int ocenaTemp = 0;
            
            if (komentar.Ocena.Equals("Nula"))
            {
                ocenaTemp = 0;
            }
            else if (komentar.Ocena.Equals("Jedan"))
            {
                ocenaTemp = 1;
            }
            else if (komentar.Ocena.Equals("Dva"))
            {
                ocenaTemp = 2;
            }
            else if (komentar.Ocena.Equals("Tri"))
            {
                ocenaTemp = 3;
            }
            else if (komentar.Ocena.Equals("Cetri"))
            {
                ocenaTemp = 4;
            }
            else if (komentar.Ocena.Equals("Pet"))
            {
                ocenaTemp = 5;
            }

            Komentar retKom = new Komentar(komentar.KorisnickoImeVozaca, DateTime.Now, Temp.M.KorisnickoIme, DateTime.Now, ocenaTemp);
            List<Voznja> temp = new List<Voznja>();
            int index = int.Parse(komentar.Lokacija2);

            foreach (Voznja voznja in Temp.M.VoznjeKorisnika)
            {
                if (voznja.StatusVoznje.Equals(StatusVoznje.Kreirana))
                {
                    temp.Add(voznja);
                }
            }
            retKom.Voznja = temp[index].Datum;

            Voznje.SveVoznje.Remove(temp[index]);
            Temp.M.VoznjeKorisnika.Remove(temp[index]);
            temp[index].Komentar = retKom;
            temp[index].StatusVoznje = StatusVoznje.Otkazana;

            Voznje.SveVoznje.Add(temp[index]);
            Temp.M.VoznjeKorisnika.Add(temp[index]);

            return Ok("Uspesno");
        }
    }
}
