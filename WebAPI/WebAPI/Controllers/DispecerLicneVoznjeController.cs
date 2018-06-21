using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DispecerLicneVoznjeController : ApiController
    {
        public List<Voznja> Get()
        {
            List<Voznja> ret = new List<Voznja>();

            foreach(Voznja v in Voznje.SveVoznje)
            {
                if(v.Dispecer.Equals(Temp.D.KorisnickoIme))
                {
                    ret.Add(v);
                }
            }

            return ret;
        }
    }
}
