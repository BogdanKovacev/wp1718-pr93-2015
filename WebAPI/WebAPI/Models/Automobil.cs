using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Automobil
    {
        Vozac vozac;
        int godisteAutomobila;
        string registracija;
        int brojTaksiVozila;
        TipVozilaEnum tipAutomobila;

        public Automobil(Vozac vozac, int godisteAutomobila, string registracija, int brojTaksiVozila, TipVozilaEnum tipAutomobila)
        {
            this.vozac = vozac;
            this.godisteAutomobila = godisteAutomobila;
            this.registracija = registracija;
            this.brojTaksiVozila = brojTaksiVozila;
            this.tipAutomobila = tipAutomobila;
        }

        public Vozac Vozac { get => vozac; set => vozac = value; }
        public int GodisteAutomobila { get => godisteAutomobila; set => godisteAutomobila = value; }
        public string Registracija { get => registracija; set => registracija = value; }
        public int BrojTaksiVozila { get => brojTaksiVozila; set => brojTaksiVozila = value; }
        public TipVozilaEnum TipAutomobila { get => tipAutomobila; set => tipAutomobila = value; }
    }
}