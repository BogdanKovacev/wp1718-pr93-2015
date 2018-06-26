using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Lokacija
    {
        public string X { get; set; }
        public string Y { get; set; }
        public string Adresa { get; set; }

        public Lokacija(string x, string y, string adresa)
        {
            this.X = x;
            this.Y = y;
            this.Adresa = adresa;
        }

        public Lokacija() { }

        public string Random()
        {
            Random r = new Random();
            return string.Format("{0}.{1}", r.Next(0, 50),r.Next(0, 100000000));
        }
        
    }
}