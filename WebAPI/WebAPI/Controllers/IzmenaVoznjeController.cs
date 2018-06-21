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
    public class IzmenaVoznjeController : ApiController
    {

        public Voznja Post(TempLokacija korisnik)
        {
            string temp = korisnik.KorisnickoImeVozaca;

            Voznja tempVoznja = null;
            List<Voznja> lista = new List<Voznja>();


            int index = Int32.Parse(temp);

            foreach (Voznja voz in Temp.M.VoznjeKorisnika)
            {
                if (voz.StatusVoznje.Equals(StatusVoznje.Kreirana))
                {
                    lista.Add(voz);
                }
            }

            tempVoznja = lista[index];

            return tempVoznja;
        }
    }
}
