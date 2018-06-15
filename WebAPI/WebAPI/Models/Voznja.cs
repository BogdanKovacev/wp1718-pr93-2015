using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Voznja
    {
        DateTime datum;
        Lokacija lokacijaTaksija;
        TipVozilaEnum tipVozila;
        Musterija musterija;
        Lokacija odrediste;
        Dispecer dispecer;
        Vozac vozac;
        double iznos;
        Komentar komentar;
        StatusVoznje statusVoznje;

        public Voznja(DateTime datum, Lokacija lokacijaTaksija, TipVozilaEnum tipVozila, Musterija musterija, Lokacija odrediste, Dispecer dispecer, Vozac vozac, double iznos, Komentar komentar, StatusVoznje statusVoznje)
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

        public DateTime Datum { get => datum; set => datum = value; }
        public Lokacija LokacijaTaksija { get => lokacijaTaksija; set => lokacijaTaksija = value; }
        public TipVozilaEnum TipVozila { get => tipVozila; set => tipVozila = value; }
        public Musterija Musterija { get => musterija; set => musterija = value; }
        public Lokacija Odrediste { get => odrediste; set => odrediste = value; }
        public Dispecer Dispecer { get => dispecer; set => dispecer = value; }
        public Vozac Vozac { get => vozac; set => vozac = value; }
        public double Iznos { get => iznos; set => iznos = value; }
        public Komentar Komentar { get => komentar; set => komentar = value; }
        public StatusVoznje StatusVoznje { get => statusVoznje; set => statusVoznje = value; }
    }
}