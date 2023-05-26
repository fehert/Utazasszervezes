using System;
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
            List<string> osszerak = new List<string>();
            string nev = "";
            string uticel = "";
            int ar = 0;
            while (true)
            {
                Console.WriteLine("[1] Utas adatok felvétele");
                Console.WriteLine("[2] Utas adatok módasítása");
                Console.WriteLine("[3] Utazás felvétele");
                Console.WriteLine("[4] Utazásra jelentkezés");
                Console.WriteLine("[5] Előleg felvétele");
                Console.WriteLine("[6] Előleg módisítása");
                Console.WriteLine("[7] Utaslista nyomtatása");
                Console.WriteLine("[8] Kilépés");
                char valasz = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (valasz)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Adja meg az utas nevét!");
                         nev = Console.ReadLine();
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
                        Console.Clear();
                        return;
                    case '3':
                        Console.WriteLine("Adja meg az uticélt");
                        uticel = Console.ReadLine();
                        Console.WriteLine("Adja meg az árat");
                        ar = int.Parse(Console.ReadLine());
                        Console.WriteLine("Adja meg a maximum létszámot");
                        int maxletszam = int.Parse(Console.ReadLine());
                        utazas1.Add(new Utazas(uticel, ar, maxletszam));
                        break;
                    case '4':
                        Console.WriteLine("Adja meg a jelentkező nevét!");
                        string nev2 = Console.ReadLine();
                        for (int j = 0; j < utas1.Count; j++)
                        {
                            if (nev2 == utas1[j].getNev())
                            {

                                Console.WriteLine("Adja meg az uticélt!");
                                string vuticel = Console.ReadLine();
                                Console.Clear();
                                for (int i = 0; i < utazas1.Count; i++)
                                {
                                    if (utazas1[i].getUticel() == vuticel)
                                    {
                                        if (utazas1[i].getMaxl() > utazas1[i].jletszam())
                                        {
                                            utazas1[i].jelentkezesutazasra(utas1[j]);
                                        }

                                    }
                                }
                                break;
                            }
                        }
                        Console.Clear();
                        break;
                    case '5':
                        Console.WriteLine("Adja meg az előleget");
                        int eloleg = int.Parse(Console.ReadLine());
                        int kulombseg = ar - eloleg;
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
                        break;
                    case '7':
                        Console.WriteLine("Melyik utazásra szeretnéd?");
                        string melyik = Console.ReadLine();
                        StreamWriter fajl = new StreamWriter("nyomtatas.txt");
                        fajl.WriteLine("Név" + '\t' + "Cím" + '\t' + "Telefonszám" + '\t' + "Fizetendő");
                        for (int i = 0; i < utazas1.Count; i++)
                        {
                            if (utazas1[i].getUticel() == melyik)
                            {
                                int eloleg1 = 0;
                                for (int e = 0; e < osszerak.Count; e++)
                                {
                                    if (osszerak[e].Split('\t')[1] == melyik)
                                    {
                                        eloleg1 = int.Parse(osszerak[e].Split('\t')[2]);
                                    }
                                }
                                List<Utas> jelentkezettek = utazas1[i].Jelentkezes();
                                for (int j = 0; j < jelentkezettek.Count; j++)
                                {
                                    fajl.WriteLine(jelentkezettek[j].getSor());
                                    fajl.WriteLine(jelentkezettek[j].getSor() + '\t' + eloleg1);

                                }
                            }
                        }
                        fajl.Close();
                        Console.Clear();
                        break;
                    case '8':
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
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
        public string getSor()
        {
            return nev + "\t" + cim + "\t" + telefonsz;
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
        int maxl;
        List<Utas> jelentkezes = new List<Utas>();
        public Utazas(string uuticel, int uar, int umaxl)
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
        public void jelentkezesutazasra(Utas u)
        {
            jelentkezes.Add(u);
        }
        public int getMaxl()
        {
            return maxl;
        }
        public int jletszam()
        {
            return jelentkezes.Count;
        }
    }
}