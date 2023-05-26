using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace utazas1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Utas> utas1 = new List<Utas>();
            List<Utazas> utazas1 = new List<Utazas>();
            List<string> osszerak = new List<string>();
            string nev = "";
            string uticel = "";
            int ar = 0;
            int kulombseg = 0;
            while (true)
            {
                Console.WriteLine("1.Utas adatok felvétele");
                Console.WriteLine("2.Utas adatok módasítása");
                Console.WriteLine("3.Utazás felvétele");
                Console.WriteLine("4.Utazásra jelentkezés");
                Console.WriteLine("5.Előleg felvétele");
                Console.WriteLine("6.Előleg módisítása");
                Console.WriteLine("7.Utaslista nyomtatása");
                Console.WriteLine("8.Kilépés");
                char valasz = Console.ReadKey().KeyChar;
                switch (valasz)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Adja meg az utas nevét!");
                        nev = Console.ReadLine();
                        Console.WriteLine("Adja meg az utas címét!");
                        string cim = Console.ReadLine();
                        Console.WriteLine("Adja meg az utas telefonszámát!");
                        string telefonsz = Console.ReadLine();
                        utas1.Add(new Utas(nev, cim, telefonsz));
                        Console.Clear();
                        break;
                    case '2':
                        Console.WriteLine("Amelyik utast szeretné módosítani adja meg a nevét!");
                        string valtozas = Console.ReadLine();
                        Console.Clear();
                        for (int i = 0; i < utas1.Count; i++)
                        {
                            if (utas1[i].getNev() == valtozas)
                            {
                                utas1.RemoveAt(i);
                                Console.WriteLine("Adja meg az utas nevét!");
                                string mnev = Console.ReadLine();
                                Console.WriteLine("Adja meg az utas címét!");
                                string mcim = Console.ReadLine();
                                Console.WriteLine("Adja meg az utas telefonszámát!");
                                string mtelefonsz = Console.ReadLine();
                                utas1.Add(new Utas(mnev, mcim, mtelefonsz));
                                Console.Clear();
                                break;
                            }

                        }
                        return;
                    case '3':
                        Console.WriteLine("Adja meg az uticélt");
                        uticel = Console.ReadLine();
                        Console.WriteLine("Adja meg az árat");
                        ar = int.Parse(Console.ReadLine());
                        Console.WriteLine("Adja meg a maximum létszámot");
                        string maxletszam = Console.ReadLine();
                        utazas1.Add(new Utazas(uticel, ar, maxletszam));
                        break;
                    case '4':
                        Console.WriteLine("Adja meg az uticélt!");
                        string vuticel = Console.ReadLine();
                        Console.Clear();
                        break;
                    case '5':
                        Console.WriteLine("Adja meg az előleget");
                        int eloleg = int.Parse(Console.ReadLine());
                        kulombseg = ar - eloleg;
                        if (ar >= kulombseg)
                        {
                            osszerak.Add(nev + "\t" + uticel + "\t" + kulombseg);
                        }
                        else if (ar < kulombseg)
                        {
                            Console.WriteLine("Az előleg túl sok!");
                        }
                        break;
                    case '6':
                        Console.WriteLine("Adja meg a nevet");
                        string nev2 = Console.ReadLine();
                        Console.WriteLine("Adja meg az uticélt");
                        string uticel2 = Console.ReadLine();
                        Console.WriteLine("Adja meg a módosított előleget");
                        int meloleg = int.Parse(Console.ReadLine());
                        for (int i = 0; i < osszerak.Count; i++)
                        {
                            if (nev2 == nev && uticel2 == uticel && ar >= kulombseg)
                            {
                                int bontas = int.Parse(osszerak[i].Split('\t')[2] + meloleg);
                                string ujsor = nev2 + "\t" + uticel2 + "\t" + bontas;
                                Console.WriteLine(ujsor);
                            }
                            else
                            {
                                Console.WriteLine("Nincs ilyen név/uticel!");
                            }
                        }

                        break;
                    case '7':
                        Console.WriteLine("Melyik utazásra szeretnéd?");
                        string melyik = Console.ReadLine();
                        StreamWriter fajl = new StreamWriter("nyomtatas.txt");
                        for (int i = 0; i < utazas1.Count; i++)
                        {
                            if (utazas1[i].getUticel() == melyik)
                            {
                                List<Utas> jelentkezettek = utazas1[i].Jelentkezes();
                                for (int j = 0; j < jelentkezettek.Count; j++)
                                {
                                    fajl.WriteLine(jelentkezettek.Count);
                                }
                            }

                        }
                        break;
                    case '8':
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
        List<Utazas> jelentkezes = new List<Utazas>();

        public Utas(string unev, string ucim, string utelefonsz)
        {
            nev = unev;
            cim = ucim;
            telefonsz = utelefonsz;

        }
        public string getUtas()
        {
            return nev + cim + telefonsz;
        }
        public string getNev()
        {
            return nev;
        }
        public List<Utazas> Jelentkezes()
        {

            return jelentkezes;
        }
    }
    class Utazas
    {
        string uticel;
        int ar;
        string maxl;
        List<Utas> jelentkezes = new List<Utas>();
        public Utazas(string uuticel, int uar, string umaxl)
        {
            uticel = uuticel;
            ar = uar;
            maxl = umaxl;
        }
        public string getUtazas()
        {
            return uticel + ar + maxl;
        }
        public string getUticel()
        {
            return uticel;
        }
        public List<Utas> Jelentkezes()
        {

            return jelentkezes;
        }
    }
}
