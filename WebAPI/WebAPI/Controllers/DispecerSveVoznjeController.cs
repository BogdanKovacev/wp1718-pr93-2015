﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DispecerSveVoznjeController : ApiController
    {
        public List<Voznja> Get()
        {
            Voznje.ListaSortiranihDispecer = Voznje.SveVoznje;
            return Voznje.SveVoznje;
        }
    }
}
