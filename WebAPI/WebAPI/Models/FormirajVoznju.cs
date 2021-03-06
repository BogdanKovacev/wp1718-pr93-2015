﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class FormirajVoznju
    {
        public string Adresa { get; set; }
        public string Vozac { get; set; }
        public TipVozilaEnum ZeljeniTipAutomobila { get; set; }
        public StatusVoznje StatusVoznje { get; set; }
        public string Iznos { get; set; }
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public string OdOcena { get; set; }
        public string DoOcena { get; set; }

        public FormirajVoznju() { }

        public FormirajVoznju(string adresa, string vozac)
        {
            Adresa = adresa;
            Vozac = vozac;
        }
    }
}