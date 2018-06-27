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
    public class VozaciController : ApiController
    {
        public List<Vozac> Get()
        {
            List<Vozac> ret = new List<Vozac>();
            List<Vozac> ret1 = new List<Vozac>();
            List<Vozac> petNajblizih = new List<Vozac>();
            double min = -1;
            foreach (Vozac vozac in ListaVozaca.Vozaci)
            {
                if (vozac.Slobodan)
                    ret.Add(vozac);
            }

            if(ret.Count <= 5)
            {
                return ret;
            }
            else
            {
                for(int i = 0; i < ret.Count(); i++)
                {
                    foreach (Voznja v in Voznje.SveVoznje)
                    {
                        double rastojanje = Math.Sqrt(Math.Pow(double.Parse(v.LokacijaTaksija.X) - double.Parse(ret[i].Lokacija.X), 2) - Math.Pow(double.Parse(v.LokacijaTaksija.Y) - double.Parse(ret[i].Lokacija.Y), 2));
                        ret[i].Rastojanje = rastojanje;
                    }
                }
                
                for(int temp = 0; temp < 5; temp++)
                {
                    min = ret[0].Rastojanje; // PRETPOSTAVKA DA JE PRVI U LISTI NAJBLIZI
                    foreach (Vozac i in ret)
                    {
                        if(min > i.Rastojanje)
                        {
                            min = i.Rastojanje;
                        }
                    }

                    foreach(Vozac v in ret)
                    {
                        if(v.Rastojanje == min)
                        {
                            petNajblizih.Add(v);
                            ret.Remove(v);
                        }
                    }

                    if(petNajblizih.Count() == 5)
                    {
                        break;
                    }
                }
                
               
                
            }

            return ret;
        }

        [ResponseType(typeof(Vozac))]
        public IHttpActionResult Post(FormirajVoznju voznja)
        {
            Lokacija l = new Lokacija("", "", voznja.Adresa);
            Voznja v = new Voznja(DateTime.Now, l, voznja.ZeljeniTipAutomobila, "", null, Temp.D.KorisnickoIme, voznja.Vozac, -1, null, StatusVoznje.Formirana);
            Temp.D.VoznjeKorisnika.Add(v);
            Voznje.SveVoznje.Add(v);

            foreach (Vozac vozac in ListaVozaca.Vozaci)
            {
                if (vozac.KorisnickoIme.Equals(voznja.Vozac))
                {
                    vozac.Slobodan = false;
                    vozac.VoznjeKorisnika.Add(v);
                    return Ok(vozac);
                }
            }
            return Ok(v);
        }
    }
}
