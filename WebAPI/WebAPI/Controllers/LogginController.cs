using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class LogginController : ApiController
    {
        [ResponseType(typeof(Korisnik))]
        public IHttpActionResult Post([FromBody]Musterija musterija)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (Musterija m in ListaMusterija.Musterije)
            {
                if (m.KorisnickoIme.Equals(musterija.KorisnickoIme))
                {
                    return BadRequest("Korisnik vec postoji");
                }
            }
            musterija.VoznjeKorisnika = new List<Voznja>();
            ListaMusterija.Musterije.Add(musterija);

            ///////////////////////// DODAJ MUSTERIJU U BAZU

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

            return CreatedAtRoute("DefaultApi", new { id = musterija.KorisnickoIme }, musterija);           
        }

        [HttpPost]
        [Route("api/Loggin/Prijava")]
        public IHttpActionResult Login(Korisnik prijava)
        {
            int mT = 0;
            int vT = 0;
            int dT = 0;

            foreach (Musterija m in ListaMusterija.Musterije)
            {
                if (m.KorisnickoIme.Equals(prijava.KorisnickoIme))
                {
                    mT = 1;
                }
            }

            foreach (Vozac m in ListaVozaca.Vozaci)
            {
                if (m.KorisnickoIme.Equals(prijava.KorisnickoIme))
                {
                    vT = 1;
                }
            }

            foreach (Dispecer m in ListaDispecera.Dispeceri)
            {
                if (m.KorisnickoIme.Equals(prijava.KorisnickoIme))
                {
                    dT = 1;
                }
            }

            if (mT != 1 && vT != 1 && dT != 1)
            {
                return BadRequest("Korisnik sa unetim korisnickim imenom ne postoji !!!");
            }

            if(mT == 1)
            {
                Musterija m1 = ListaMusterija.Musterije.Find(x => x.KorisnickoIme == prijava.KorisnickoIme);
                if (m1.Lozinka != prijava.Lozinka)
                    return BadRequest("Neispravna lozinka !!!");

                Temp.M = m1;
                HttpContext.Current.Session["ulogovan"] = Temp.M as Musterija;
                return Ok(m1);
            }
            else if (dT == 1)
            {
                Dispecer m1 = ListaDispecera.Dispeceri.Find(x => x.KorisnickoIme == prijava.KorisnickoIme);
                if (m1.Lozinka != prijava.Lozinka)
                    return BadRequest("Neispravna lozinka !!!");

                Temp.D = m1;
                HttpContext.Current.Session["ulogovan"] = Temp.D as Dispecer;
                return Ok(m1);
            }
            else
            {
                Vozac m1 = ListaVozaca.Vozaci.Find(x => x.KorisnickoIme == prijava.KorisnickoIme);
                if (m1.Lozinka != prijava.Lozinka)
                    return BadRequest("Neispravna lozinka !!!");

                Temp.V = m1;
                HttpContext.Current.Session["ulogovan"] = Temp.V as Vozac;
                return Ok(m1);
            }
        }

        public Korisnik Get()
        {
            Korisnik k = (Korisnik)HttpContext.Current.Session["ulogovan"];
            
            return k;
        }

    }
}
