﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SveVoznjeMusterijaController : ApiController
    {
        public List<Voznja> Get()
        {
            List<Voznja> ret = new List<Voznja>();

            foreach (Voznja voznja in Voznje.SveVoznje)
            {
                if (voznja.Musterija.Equals(Temp.M.KorisnickoIme))
                {
                    ret.Add(voznja);
                }
            }

            Voznje.ListaSortiranih = ret;

            return ret;
        }
    }
}
