using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TrenutnaVoznjaController : ApiController
    {
        public Voznja Get()
        {
            foreach (Voznja voznja in Temp.V.VoznjeKorisnika)
            {
                if (voznja.StatusVoznje.Equals(StatusVoznje.Kreirana) || voznja.StatusVoznje.Equals(StatusVoznje.Formirana))
                    return voznja;
            }

            return null;
        }

        public string Post(FormirajVoznju voznja)
        {
            foreach (Voznja v in Voznje.SveVoznje)
            {
                if (v.LokacijaTaksija.Adresa.Equals(voznja.Adresa))
                {
                    if (voznja.StatusVoznje.Equals(StatusVoznje.Neuspesna))
                    {
                        return "komentar";
                    }
                    else if (voznja.StatusVoznje.Equals(StatusVoznje.Uspesna))
                    {
                        return "unos";
                    }
                }
            }

            return "";
        }
    }
}
