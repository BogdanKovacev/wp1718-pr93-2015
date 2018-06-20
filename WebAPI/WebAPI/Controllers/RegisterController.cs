using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class RegisterController : ApiController
    {
        public RedirectResult Post([FromBody]Musterija musterija)
        {
            if (!musterija.KorisnickoIme.Equals(null))
            {
                int i = 0;
                foreach (Musterija m in ListaMusterija.Musterije)
                {
                    if (musterija.KorisnickoIme.Equals(m.KorisnickoIme))
                    {
                        i++;
                    }
                }
                if (i == 0)
                {
                    ListaMusterija.Musterije.Add(musterija);
                }
            }

            return Redirect("http://localhost:10482/" + "login.html");

        }
    }
}
