﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SveVoznjeVozacaController : ApiController
    {
        public List<Voznja> Get()
        {
            List<Voznja> ret = new List<Voznja>();

            foreach (Voznja voznja in Voznje.SveVoznje)
            {
                if (voznja.Vozac.Equals(Temp.V.KorisnickoIme))
                {
                    ret.Add(voznja);
                }
            }

            Voznje.ListaSortiranihVozac = ret;

            return ret;
        }
    }
}
