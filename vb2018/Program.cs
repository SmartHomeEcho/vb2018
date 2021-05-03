using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace vb2018
{
    class Program
    {
        static void Main(string[] args)
        {
            Beolvasas();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"3. feladat: Stadionok száma:{adatok.Count}");
            Console.WriteLine($"4. feladat: A legkevesebb férőhely:");
            Console.WriteLine($"\t Város:{adatok.OrderBy(a => a.Ferohely).First().Varos}");
            Console.WriteLine($"\t Város:{adatok.OrderBy(a => a.Ferohely).First().Nev1}");
            Console.WriteLine($"\t Város:{adatok.OrderBy(a => a.Ferohely).First().Ferohely}");
            Atlagos_hely();//5. feladat
            Alternativ_nev();//6. feladat
            VarosNev();//7. feladat-8.feladat
            Kulonbozomerkozesek();//9. feladat Linq-val
            Console.ReadKey();
        }
        private static List<Labdarugas> adatok = new List<Labdarugas>();
        private static void Beolvasas()
        {
            StreamReader Olvas = new StreamReader("vb2018.txt", Encoding.Default);
            string fejlec = Olvas.ReadLine();
            while (!Olvas.EndOfStream)
            {
                adatok.Add(new Labdarugas(Olvas.ReadLine()));
            }
            Olvas.Close();
        }
        private static void Atlagos_hely()
        {
            double osszesen = 0;
            double darab = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                osszesen = adatok[i].Ferohely + osszesen;
                darab++;
            }
            double atlag = osszesen / darab;
            Console.WriteLine($"5. feladat: Átlagos férőhelyszám: {Math.Round(atlag, 1)}");
        }
        private static void Alternativ_nev()
        {
            int darab = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Nev2 != "n.a.")
                {
                    darab++;
                }
            }
            Console.WriteLine($"6. feladat: Két néven is ismert stadionok száma:{darab}");
        }
        private static void VarosNev()
        {
            Console.Write("7. feladat: kérem egy város nevét:");
            string bevittnev = Console.ReadLine();
            while (bevittnev.Length<=3)
            {
                Console.Write("7. feladat: kérem egy város nevét:");
                bevittnev = Console.ReadLine();
            }
            bool benevan = false;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (bevittnev.Contains(adatok[i].Varos))
                {
                    benevan = true;
                }
            }
            if (benevan==true)
            {
                Console.WriteLine($"8. feladat: A megadott város VB helyszín");
            }
            else
            {
                Console.WriteLine($"8. feladat: A megadott város nem VB helyszín");
            }
        }
        private static void Kulonbozomerkozesek()
        {
            Console.WriteLine($"9. feladat:{adatok.GroupBy(a => a.Varos).Count()} városban voltak mérkőzések.");
            //adatok.GroupBy(a => a.Varos).ToList().ForEach(b => Console.WriteLine($"9. feladat: {b.Key} városban voltak mérkőzések. {b.Count()} "));
        }
    }
    
    class Labdarugas
    {
        public Labdarugas(string sor)
        {
            string[] sorelemek = sor.Split(';');
            this.Varos = sorelemek[0];
            this.Nev1 = sorelemek[1];
            this.Nev2 = sorelemek[2];
            this.Ferohely = Convert.ToInt32(sorelemek[3]);   
        }
    public string Varos { get; set; }
    public string Nev1 { get; set; }
    public string Nev2 { get; set; }
    public int Ferohely { get; set; }
    }
}
