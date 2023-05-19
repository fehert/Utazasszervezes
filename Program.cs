﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace utazas1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Utas> utas1 = new List<Utas>();
            List<Utazas> utazas1 = new List<Utazas>();
            while (true)
            {
                Console.WriteLine("1.Utas adatok felvétele");
                Console.WriteLine("3.Utazás felvétele");
                Console.WriteLine("5.Kilépés");
                char valasz = Console.ReadKey().KeyChar;
                switch (valasz)
                {
                    case '1':
                        Console.WriteLine("Adja meg az utas nevét!");
                        string nev = Console.ReadLine();
                        Console.WriteLine("Adja meg az utas címét!");
                        string cim = Console.ReadLine();
                        Console.WriteLine("Adja meg az utas telefonszámát!");
                        string telefonsz = Console.ReadLine();
                        utas1.Add(new Utas(nev,cim,telefonsz));
                        Console.Clear();
                        break;
                    case '3':
                        Console.WriteLine("Adja meg az uticélt");
                        string uticel = Console.ReadLine();
                        Console.WriteLine("Adja meg az árat");
                        string ar = Console.ReadLine();
                        Console.WriteLine("Adja meg a maximum létszámot");
                        string maxletszam = Console.ReadLine();
                        utazas1.Add(new Utazas(uticel,ar,maxletszam));
                        break;
                    case '5':
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
    class Utas
    {
        string nev;
        string cim;
        string telefonsz;
        
        public Utas(string unev,string ucim,string utelefonsz)
        {
            nev = unev;
            cim = ucim;
            telefonsz = utelefonsz;
            
        }
        public string getUtas()
        {
            return nev+cim+telefonsz;
        }
    }
    class Utazas
    {
        string uticel;
        string ar;
        string maxl;
        public Utazas(string uuticel, string uar,string umaxl)
        {
            uticel = uuticel;
            ar = uar;
            maxl = umaxl;
        }
        public string getUtazas()
        {
            return uticel+ar+maxl;
        }
    }
}