﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DispecerDodajVozacaController : ApiController
    {
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(Vozac vozac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach(Vozac v in ListaVozaca.Vozaci)
            {
                if(v.KorisnickoIme.Equals(vozac.KorisnickoIme))
                {
                    return BadRequest("Vozac vec postoji !!!");
                }
            }

            Vozac vozacP = new Vozac(vozac.KorisnickoIme, vozac.Lozinka, vozac.Ime, vozac.Prezime, vozac.Pol, vozac.Jmbg, vozac.KontaktTelefon, vozac.Email, UlogaEnum.Vozac, vozac.VoznjeKorisnika, null,null);
            foreach (Automobil automobil in ListaAutomobila.Vozila)
            {
                if (automobil.Slobodan)
                {
                    vozacP.Automobil = automobil;
                    automobil.Slobodan = false;
                    automobil.Vozac = vozacP.KorisnickoIme;
                    vozacP.Automobil = automobil;
                    break;
                }
            }

            vozacP.Lokacija = new Lokacija("44°49'04.127", "44°49'04.127", "Sutjeska 3, Novi Sad 21000");

            ListaVozaca.Vozaci.Add(vozacP);
            return StatusCode(HttpStatusCode.NoContent);

        }
    }
}