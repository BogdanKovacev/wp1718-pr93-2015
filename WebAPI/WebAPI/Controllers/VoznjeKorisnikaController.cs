using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class VoznjeKorisnikaController : ApiController
    {
        public List<Voznja> Get()
        {
            List<Voznja> lista = new List<Voznja>();

            foreach(Voznja v in Temp.M.VoznjeKorisnika)
            {
                if(v.StatusVoznje.Equals(StatusVoznje.Kreirana))
                {
                    lista.Add(v);
                }
            }

            return lista;
        }
    }
}
