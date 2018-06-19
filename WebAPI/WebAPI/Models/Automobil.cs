using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Automobil
    {
        public string Vozac { get; set; }
        public int GodisteAutomobila { get; set; }
        public string Registracija { get; set; } 
        public int BrojTaksiVozila { get; set; }
        public TipVozilaEnum TipAutomobila { get; set; }
        public bool Slobodan { get; set; }

        public Automobil(string vozac, int godisteAutomobila, string registracija, int brojTaksiVozila, TipVozilaEnum tipAutomobila)
        {
            this.Vozac = vozac;
            this.GodisteAutomobila = godisteAutomobila;
            this.Registracija = registracija;
            this.BrojTaksiVozila = brojTaksiVozila;
            this.TipAutomobila = tipAutomobila;
            Slobodan = true;
        }

        public Automobil()
        {

        }
        
    }
}