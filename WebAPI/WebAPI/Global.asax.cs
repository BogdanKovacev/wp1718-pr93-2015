using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAPI.Models;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ListaMusterija.Musterije = new List<Musterija>();
            ListaVozaca.Vozaci = new List<Vozac>();
            ListaDispecera.Dispeceri = new List<Dispecer>();
            ListaAutomobila.Create();
            ListaVozaca.Vozaci.Add(new Vozac("vozac","aaaaa","Ivan","Benis",PolEnum.Muski,"2004996800115","0","a@a.a",UlogaEnum.Vozac,null, new Lokacija("44°49'04.127", "44°49'04.127", "Sutjeska 3, Novi Sad 21000"),ListaAutomobila.Vozila[3]));
            ListaMusterija.Musterije.Add(new Musterija("Dasa", "aaaaa", "Ivan", "Benis", PolEnum.Muski, "2004996800115", "0", "a@a.a", UlogaEnum.Musterija, null));

            Voznje.CreateVoznje();
            string text = System.IO.File.ReadAllText(@"E:\faks\treca\WEB\Projekat\wp1718-pr93-2015\WebAPI\WebAPI\dispeceri.txt");
            string[] line = text.Split('=',';');
            int count = line.Count()/18;
            for(int i = 0; i < count ; i++)
            {
                PolEnum polTemp = PolEnum.Muski;
                if (line[18*i + 9].Equals("Muski"))
                {
                    polTemp = PolEnum.Muski;
                }
                else
                {
                    polTemp = PolEnum.Zenski;
                }

                List<Voznja> listaTemp = new List<Voznja>();

                foreach(Musterija m in ListaMusterija.Musterije)
                {
                    foreach(Voznja v in m.VoznjeKorisnika)
                    {
                        listaTemp.Add(v);
                    }
                }

                ListaDispecera.Dispeceri.Add(new Dispecer(line[i*18+1], line[i * 18 + 3], line[i * 18 + 5], line[i * 18 + 7], polTemp, line[i * 18 + 11], line[i * 18 + 13], line[i * 18 + 15], UlogaEnum.Dispecer, listaTemp));
            }
        }
    }
}
