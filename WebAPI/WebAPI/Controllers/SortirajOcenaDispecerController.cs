﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SortirajOcenaDispecerController : ApiController
    {
        public List<Voznja> Get()
        {
            List<Voznja> temp = new List<Voznja>();
            temp = Voznje.ListaSortiranihDispecer;
            List<Voznja> ret = new List<Voznja>();

            for (int i = 5; i >= 0; i--)
            {
                foreach (Voznja voznja in temp)
                {
                    if (voznja.Komentar == null)
                    {

                    }
                    else
                    {
                        if ((int)voznja.Komentar.OcenaVoznje == i)
                        {
                            ret.Add(voznja);
                        }
                    }
                }
            }

            return ret;
        }
    }
}
