﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Voznje
    {
        public static List<Voznja> SveVoznje { get; set; }
        public static List<Voznja> ListaSortiranih { get; set; }
        public static List<Voznja> ListaSortiranihVozac { get; set; }
        public static List<Voznja> ListaSortiranihDispecer { get; set; }
        public static void CreateVoznje()
        {
            SveVoznje = new List<Voznja>();
            ListaSortiranih = new List<Voznja>();
            ListaSortiranihVozac = new List<Voznja>();
            ListaSortiranihDispecer = new List<Voznja>();
        }
    }
}