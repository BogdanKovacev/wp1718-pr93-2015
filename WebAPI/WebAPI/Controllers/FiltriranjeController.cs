﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class FiltriranjeController : ApiController
    {
        public List<Voznja> Post(FormirajVoznju forma)
        {
            List<Voznja> ret = new List<Voznja>();

            foreach (Voznja voznja in Voznje.ListaSortiranih)
            {
                if (voznja.StatusVoznje.Equals(forma.StatusVoznje))
                    ret.Add(voznja);
            }

            return ret;
        }
    }
}
