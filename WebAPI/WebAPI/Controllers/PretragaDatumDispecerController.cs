using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PretragaDatumDispecerController : ApiController
    {
        public List<Voznja> Post(FormirajVoznju datum)
        {
            List<Voznja> ret = new List<Voznja>();
            DateTime value = new DateTime(1, 1, 1);
            string temp = "";
            if (!datum.Od.Equals(value))
            {
                if (!datum.Do.Equals(value))
                {
                    temp = "od-do";
                }
                else
                    temp = "od";
            }
            else
            {
                if (!datum.Do.Equals(value))
                {
                    temp = "do";
                }
                else
                {
                    ret = new List<Voznja>();
                }
            }

            if (temp.Equals("od"))
            {
                foreach (Voznja voznja in Voznje.ListaSortiranihDispecer)
                {
                    if (voznja.Datum >= datum.Od)
                        ret.Add(voznja);
                }
            }
            else if (temp.Equals("do"))
            {
                foreach (Voznja voznja in Voznje.ListaSortiranihDispecer)
                {
                    if (voznja.Datum <= datum.Do)
                        ret.Add(voznja);
                }
            }
            else if (temp.Equals("od-do"))
            {
                foreach (Voznja voznja in Voznje.ListaSortiranihDispecer)
                {
                    if (voznja.Datum >= datum.Od && voznja.Datum <= datum.Do)
                        ret.Add(voznja);
                }
            }

            Voznje.ListaSortiranihDispecer = ret;

            return ret;
        }
    }
}
