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
    public class VozacLokacijaController : ApiController
    {
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(TempLokacija lokacija)
        {

            string[] temp = lokacija.Lokacija2.Split(',',' ');

            if(temp.Count() < 4)
            {
                return BadRequest("Formatu adrese: Ulica broj, Naseljeno mesto Pozivni broj mesta (npr. Sutjeska 3, Novi Sad 21000)");
            }

            Temp.V.Lokacija.Adresa = lokacija.Lokacija2;
            Random r = new Random();
            Temp.V.Lokacija.X = string.Format("{0}°{1}'{2}.{3}", r.Next(0, 50),r.Next(0, 50), r.Next(0, 50), r.Next(0, 130));
            Temp.V.Lokacija.Y = string.Format("{0}°{1}'{2}.{3}", r.Next(0, 50), r.Next(0, 50), r.Next(0, 50), r.Next(0, 130));

            foreach(Vozac v in ListaVozaca.Vozaci)
            {
                int p = 0;
                if(v.KorisnickoIme.Equals(lokacija.KorisnickoImeVozaca))
                {
                    ListaVozaca.Vozaci[p].Lokacija.Adresa = Temp.V.Lokacija.Adresa;
                    ListaVozaca.Vozaci[p].Lokacija.X = Temp.V.Lokacija.X;
                    ListaVozaca.Vozaci[p].Lokacija.Y = Temp.V.Lokacija.Y;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public Vozac Get()
        {
            return Temp.V;
        }
    }
}
