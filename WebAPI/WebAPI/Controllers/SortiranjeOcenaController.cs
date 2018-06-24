using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SortiranjeOcenaController : ApiController
    {
        public List<Voznja> Get()
        {
            List<Voznja> temp = new List<Voznja>();
            temp = Voznje.SveVoznje;
            List<Voznja> ret = new List<Voznja>();

            for(int i = 5; i >= 0; i--)
            {
                foreach (Voznja voznja in temp)
                {
                    if(voznja.Komentar == null)
                    {
                        //AKO JE NULL KOMENTAR TJ NIJE OCENJENA VOZNJA ONDA NISTA NE RADI SA TOM VOZNJOM
                    }
                    else
                    {
                        if (voznja.Komentar.OcenaVoznje.Equals(i))
                        {
                            ret.Add(voznja);
                        }
                    }
                    
                }
            }
            

            return ret;
        }
    }
}
