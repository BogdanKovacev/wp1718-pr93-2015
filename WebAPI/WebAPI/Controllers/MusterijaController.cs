using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class MusterijaController : ApiController
    {
       /* public RedirectResult Post([FromBody]Musterija korisnik)
        {
            Temp.M = korisnik;

            foreach (Musterija musterija in ListaMusterija.Musterije)
            {
                if (musterija.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                {
                    ListaMusterija.Musterije.Remove(musterija);
                    List<Voznja> listaV = musterija.VoznjeKorisnika;
                    ListaMusterija.Musterije.Add(new Musterija(korisnik.KorisnickoIme,korisnik.Lozinka,korisnik.Ime,korisnik.Prezime,korisnik.Pol,korisnik.Jmbg,korisnik.KontaktTelefon,korisnik.Email,UlogaEnum.Musterija,listaV));
                    break;
                }
            }

            return Redirect("http://localhost:10482/musterija.html");
        }*/

        [ResponseType(typeof(void))]
        public IHttpActionResult Post(Musterija korisnik)
        {            

            Temp.M = korisnik;

            foreach (Musterija musterija in ListaMusterija.Musterije)
            {
                if (musterija.KorisnickoIme.Equals(korisnik.KorisnickoIme))
                {
                    ListaMusterija.Musterije.Remove(musterija);
                    List<Voznja> listaV = musterija.VoznjeKorisnika;
                    ListaMusterija.Musterije.Add(new Musterija(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.Jmbg, korisnik.KontaktTelefon, korisnik.Email, UlogaEnum.Musterija, listaV));
                    break;
                }
            }

            ////////////////////////////// IZMENI MUSTERIJU U BAZI

            string line = "";

            foreach (Musterija d in ListaMusterija.Musterije)
            {
                string pol = "";

                if (d.Pol == PolEnum.Muski)
                {
                    pol = "Muski";
                }
                else
                {
                    pol = "Zenski";
                }

                line += d.KorisnickoIme + "," + d.Lozinka + "," + d.Ime + "," + d.Prezime + "," + pol + "," + d.Jmbg + "," + d.KontaktTelefon + "," + d.Email + ";";
            }

            File.WriteAllText(@"E:\faks\treca\WEB\Projekat\wp1718-pr93-2015\WebAPI\WebAPI\musterije.txt", line);

            return StatusCode(HttpStatusCode.OK);
        }

        public Musterija Get()
        {
            return Temp.M;
        }
    }
}
