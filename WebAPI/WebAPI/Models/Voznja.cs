using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Voznja
    {        
        public DateTime Datum { get; set; }
        public Lokacija LokacijaTaksija { get; set; }
        public TipVozilaEnum TipVozila { get; set; }
        public string Musterija { get; set; }
        public Lokacija Odrediste { get; set; }
        public string Dispecer { get; set; }
        public string Vozac { get; set; }
        public double Iznos { get; set; }
        public Komentar Komentar { get; set; }
        public StatusVoznje StatusVoznje { get; set; }

        public Voznja(DateTime datum, Lokacija lokacijaTaksija, TipVozilaEnum tipVozila, string musterija, Lokacija odrediste, string dispecer, string vozac, double iznos, Komentar komentar, StatusVoznje statusVoznje)
        {
            this.Datum = datum;
            this.LokacijaTaksija = lokacijaTaksija;
            this.TipVozila = tipVozila;
            this.Musterija = musterija;
            this.Odrediste = odrediste;
            this.Dispecer = dispecer;
            this.Vozac = vozac;
            this.Iznos = iznos;
            this.Komentar = komentar;
            this.StatusVoznje = statusVoznje;
        }

        public Voznja()
        {

        }
    }
}