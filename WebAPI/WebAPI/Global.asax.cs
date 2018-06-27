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
        protected void Application_PostAuthorizeRequest()
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
        }
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
            /*ListaVozaca.Vozaci.Add(new Vozac("vozac1","aaaaa","Ivan","Benis",PolEnum.Muski,"2004996800115","0","a@a.a",UlogaEnum.Vozac,null, new Lokacija("44°49'04.127", "44°49'04.127", "Sutjeska 3, Novi Sad 21000"),ListaAutomobila.Vozila[3]));
            ListaVozaca.Vozaci.Add(new Vozac("vozac2", "aaaaa", "Ivan", "Benis", PolEnum.Muski, "2004996800115", "0", "a@a.a", UlogaEnum.Vozac, null, new Lokacija("44°49'04.127", "44°49'04.127", "Sutjeska 3, Novi Sad 21000"), ListaAutomobila.Vozila[3]));
            ListaVozaca.Vozaci.Add(new Vozac("vozac3", "aaaaa", "Ivan", "Benis", PolEnum.Muski, "2004996800115", "0", "a@a.a", UlogaEnum.Vozac, null, new Lokacija("44°49'04.127", "44°49'04.127", "Sutjeska 3, Novi Sad 21000"), ListaAutomobila.Vozila[3]));*/
            Temp t = new Temp();
            //ListaMusterija.Musterije.Add(new Musterija("Dasa", "aaaaa", "Ivan", "Benis", PolEnum.Muski, "2004996800115", "0", "a@a.a", UlogaEnum.Musterija,null));

            Voznje.CreateVoznje();

            ////////////////////////////////////// UCITAVANJE VOZNJI IZ FAJLA
            string textVoznje = System.IO.File.ReadAllText(@"E:\faks\treca\WEB\Projekat\wp1718-pr93-2015\WebAPI\WebAPI\voznje.txt");
            string[] lineVoznje = textVoznje.Split(',',';');
            int countVoznje = lineVoznje.Count() / 20;
            for(int i = 0; i < countVoznje;i++)
            {
                DateTime Datum = DateTime.Parse(lineVoznje[i*20]);

                string x = lineVoznje[i * 20 + 1];
                string y = lineVoznje[i * 20 + 2];
                string adresa = lineVoznje[i * 20 + 3];
                adresa += ",";
                adresa += lineVoznje[i * 20 + 4];
                Lokacija lokacijaTaxija = new Lokacija(x, y, adresa);

                TipVozilaEnum tipVozila = TipVozilaEnum.Podrazumevani;

                if(lineVoznje[i * 20 + 5].Equals("Putnicki"))
                {
                    tipVozila = TipVozilaEnum.Putnicki;
                }
                else if (lineVoznje[i * 20 + 5].Equals("Kombi"))
                {
                    tipVozila = TipVozilaEnum.Kombi;
                }
                else
                {
                    tipVozila = TipVozilaEnum.Podrazumevani;
                }

                string Musterija = lineVoznje[i * 20 + 6];

                string x1 = lineVoznje[i * 20 + 7];
                string y1 = lineVoznje[i * 20 + 8];
                string adresa1 = lineVoznje[i * 20 + 9];
                adresa1 += ",";
                adresa1 += lineVoznje[i * 20 + 10];
                Lokacija odrediste = new Lokacija(x1, y1, adresa1);

                string Dispecer = lineVoznje[i * 20 + 11];
                string Vozac = lineVoznje[i * 20 + 12];
                double Iznos = Double.Parse(lineVoznje[i * 20 + 13]);

                string Opis = lineVoznje[i * 20 + 14];
                DateTime datumObjave = DateTime.Parse(lineVoznje[i * 20 + 15]);
                string KomentarKorisnik = lineVoznje[i * 20 + 16];
                DateTime Voznja = DateTime.Parse(lineVoznje[i * 20 + 17]);
                int ocenaVoznje = Int32.Parse(lineVoznje[i * 20 + 18]);

                Komentar Komentar = new Komentar(Opis,datumObjave,KomentarKorisnik,Voznja,ocenaVoznje);

                StatusVoznje statusVoznje = StatusVoznje.Kreirana;

                if(lineVoznje[i * 20 + 19].Equals("Kreirana"))
                {
                    statusVoznje = StatusVoznje.Kreirana;
                }
                else if (lineVoznje[i * 20 + 19].Equals("Otkazana"))
                {
                    statusVoznje = StatusVoznje.Otkazana;
                }
                else if (lineVoznje[i * 20 + 19].Equals("Formirana"))
                {
                    statusVoznje = StatusVoznje.Formirana;
                }
                else if (lineVoznje[i * 20 + 19].Equals("Odradjena"))
                {
                    statusVoznje = StatusVoznje.Odradjena;
                }
                else if (lineVoznje[i * 20 + 19].Equals("Prihvacena"))
                {
                    statusVoznje = StatusVoznje.Prihvacena;
                }
                else if (lineVoznje[i * 20 + 19].Equals("Neuspesna"))
                {
                    statusVoznje = StatusVoznje.Neuspesna;
                }
                else if (lineVoznje[i * 20 + 19].Equals("Uspesna"))
                {
                    statusVoznje = StatusVoznje.Uspesna;
                }

                Voznje.SveVoznje.Add(new Voznja(Datum,lokacijaTaxija, tipVozila, Musterija, odrediste, Dispecer, Vozac, Iznos, Komentar, statusVoznje));

            }

            ////////////////////////////////////// UCITAVANJE DISPECERA IZ FAJLA

            string text = System.IO.File.ReadAllText(@"E:\faks\treca\WEB\Projekat\wp1718-pr93-2015\WebAPI\WebAPI\dispeceri.txt");
            string[] line = text.Split(',', ';');
            int count = line.Count() / 8;
            for (int i = 0; i < count; i++)
            {
                PolEnum polTemp = PolEnum.Muski;
                if (line[8 * i + 4].Equals("Muski"))
                {
                    polTemp = PolEnum.Muski;
                }
                else
                {
                    polTemp = PolEnum.Zenski;
                }

                List<Voznja> listaTemp = new List<Voznja>();

                string korisnickoIme = line[i * 8];

                foreach (Voznja v in Voznje.SveVoznje)
                {
                    if (v.Musterija.Equals(korisnickoIme))
                    {
                        listaTemp.Add(v);
                    }
                }

                ListaDispecera.Dispeceri.Add(new Dispecer(line[i * 8], line[i * 8 + 1], line[i * 8 + 2], line[i * 8 + 3], polTemp, line[i * 8 + 5], line[i * 8 + 6], line[i * 8 + 7], UlogaEnum.Dispecer, listaTemp));
            }

            ///////////////////////////////// UCITAVANJE MUSTERIJA IZ FAJLA

            string text1 = System.IO.File.ReadAllText(@"E:\faks\treca\WEB\Projekat\wp1718-pr93-2015\WebAPI\WebAPI\musterije.txt");
            string[] line1 = text1.Split(',', ';');
            int count1 = line1.Count() / 8;
            for (int i = 0; i < count1; i++)
            {
                PolEnum polTemp2 = PolEnum.Muski;
                if (line1[8 * i + 4].Equals("Muski"))
                {
                    polTemp2 = PolEnum.Muski;
                }
                else
                {
                    polTemp2 = PolEnum.Zenski;
                }

                List<Voznja> listaTemp2 = new List<Voznja>();

                string korisnickoIme = line1[i*8];

                foreach (Voznja v in Voznje.SveVoznje)
                {
                    if(v.Musterija.Equals(korisnickoIme))
                    {
                        listaTemp2.Add(v);
                    }
                }

                ListaMusterija.Musterije.Add(new Musterija(line1[i*8],line1[i*8+1], line1[i*8+2], line1[i*8+3],polTemp2, line1[i*8+5], line1[i*8+6], line1[i*8+7],UlogaEnum.Musterija,listaTemp2));
                
            }

            ///////////////////////////////// UCITAVANJE VOZACA IZ FAJLA

            string text2 = System.IO.File.ReadAllText(@"E:\faks\treca\WEB\Projekat\wp1718-pr93-2015\WebAPI\WebAPI\vozaci.txt");
            string[] line2 = text2.Split(',', ';');
            int count2 = line2.Count() / 12;
            for (int i = 0; i < count2; i++)
            {
                PolEnum polTemp3 = PolEnum.Muski;
                if (line2[12 * i + 4].Equals("Muski"))
                {
                    polTemp3 = PolEnum.Muski;
                }
                else
                {
                    polTemp3 = PolEnum.Zenski;
                }

                List<Voznja> listaTemp2 = new List<Voznja>();

                string korisnickoIme = line2[i * 12];

                foreach (Voznja v in Voznje.SveVoznje)
                {
                    if (v.Musterija.Equals(korisnickoIme))
                    {
                        listaTemp2.Add(v);
                    }
                }

                string x = line2[i*12+8];
                string y = line2[i * 12 + 9];
                string adresa = line2[i*12+10];
                adresa += ",";
                adresa += line2[i * 12 + 11];
                Lokacija lok = new Lokacija(x,y,adresa);

                ListaVozaca.Vozaci.Add(new Vozac(line2[i * 12], line2[i * 12 + 1], line2[i *12 + 2], line2[i * 12 + 3], polTemp3, line2[i *12 + 5], line2[i * 12+ 6], line2[i * 12 + 7], UlogaEnum.Vozac, listaTemp2,lok,ListaAutomobila.Vozila[i%10]));
            }

        }
    }
}
