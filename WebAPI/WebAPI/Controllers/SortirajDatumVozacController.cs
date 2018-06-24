﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SortirajDatumVozacController : ApiController
    {
        public List<Voznja> Post()
        {
            List<Voznja> ret = new List<Voznja>();
            ret = Voznje.ListaSortiranihVozac;

            foreach (Voznja voznja in ret)
            {
                ret.Sort((x, y) => DateTime.Compare(y.Datum, x.Datum));
            }

            return ret;
        }
    }
}