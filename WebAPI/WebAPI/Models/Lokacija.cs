using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Lokacija
    {
        int x;
        int y;
        string adresa;

        public Lokacija(int x, int y, string adresa)
        {
            this.X = x;
            this.Y = y;
            this.Adresa = adresa;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string Adresa { get => adresa; set => adresa = value; }
    }
}