using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvarozok_SchuhS
{
    class Program
    {
        static string[] NevekTMB = new string[21];
        static int[] FuvarHosszKmTMB = new int[21];
        static int[] FuvaridoTMB = new int[21];
        static int[] KoltsegTMB= new int[21];
        static int[] BorravaloTMB = new int[21];
        static int[] ElszamolasTMB= new int[21];
        static void Main(string[] args)
        {
            Feladat0AdatokFeltolt(); Console.WriteLine("<---------------------------------------------->");
            Feladat1Kiiratas(); Console.WriteLine("<---------------------------------------------->");
            Feladat2Elszamolas(); Console.WriteLine("<---------------------------------------------->");
            Feladat3MinMax(); Console.WriteLine("<---------------------------------------------->");
            Feladat4Atlag(); Console.WriteLine("<---------------------------------------------->");
            Feladat5Leszamolas(); Console.WriteLine("<---------------------------------------------->");
            Feladat6Keres(); Console.WriteLine("<---------------------------------------------->");
            Console.ReadKey();
        }

        private static void Feladat6Keres()
        {
            Console.WriteLine("6.Feladat: Keresés fuvarozó névre");
            Console.Write("Kérem adja meg a fuvarozó nevét: ");
            string KeresFuvarozo = Console.ReadLine().ToLower().Replace(" ","");
            int Szamlalo = 0;
            while(Szamlalo<NevekTMB.Length && KeresFuvarozo!=NevekTMB[Szamlalo].ToLower().Replace(" ", ""))
            {
                Szamlalo++;
            }
            if(Szamlalo==NevekTMB.Length)
            {
                Console.WriteLine("Nincs ilyen fuvarozó");
            }
            else
            {
                Console.WriteLine("Van ilyen fuvarozó");
                Console.WriteLine("Keresett személy: {0}", NevekTMB[Szamlalo]);
                Console.WriteLine("Ennyi volt a elszámolás: {0}",ElszamolasTMB[Szamlalo]);
            }
        }

        private static void Feladat5Leszamolas()
        {
            Console.WriteLine("5.feladat:Átlag feletti ktg ");
            double OsszKTG = 0;
            double AtlagKTG = 0;
            for (int i = 0; i < KoltsegTMB.Length; i++)
            {
                OsszKTG +=(double) KoltsegTMB[i];
            }
            AtlagKTG = (double)OsszKTG / KoltsegTMB.Length;
            int db = 0;
            for (int i = 0; i < KoltsegTMB.Length; i++)
            {
                if(KoltsegTMB[i]>AtlagKTG)
                { 
                    db++;
                }
            }
            Console.WriteLine("Átlag költség: {0:0.00}", AtlagKTG);
            Console.WriteLine("Ennyi alkalommal volt az átlag felett a dolgozó ktg-je: {0}", db);
        }

        private static void Feladat4Atlag()
        {
            Console.WriteLine("4.Feladat Átlag borravaló");
            double OsszesBorravalo = 0;
            double AtlagBorravalo = 0;
            for (int i = 0; i < NevekTMB.Length; i++)
            {
                OsszesBorravalo += (double)BorravaloTMB[i];
            }
            AtlagBorravalo = OsszesBorravalo / BorravaloTMB.Length;
            Console.WriteLine("A borravalók átlaga: {0:0.00}", AtlagBorravalo);
            double ElszamolasAtlaga = 0;
            double Elszamolas = 0;
            for (int i = 0; i < NevekTMB.Length; i++)
            {
                Elszamolas += (double)(FuvarHosszKmTMB[i] * 11 + FuvaridoTMB[i] * 3 - KoltsegTMB[i] * 2 + BorravaloTMB[i]);                
            }
            ElszamolasAtlaga = Elszamolas / ElszamolasTMB.Length;
            Console.WriteLine("Az elszámolásban átlag ennyit kerestek: {0:0.00}", ElszamolasAtlaga);

        }

        private static void Feladat3MinMax()
        {
            Console.WriteLine("3.Feladat: Minimum, maximum távolság");
            int MinTavolsag = int.MaxValue;
            int MaxTavolsag = int.MinValue;
            string MinNev = "";
            string MaxNEv = "";
            for (int i = 0; i < NevekTMB.Length; i++)
            {
                if(FuvarHosszKmTMB[i]<MinTavolsag)
                {
                    MinTavolsag = FuvarHosszKmTMB[i];
                    MinNev = NevekTMB[i];
                }
                if(MaxTavolsag<FuvarHosszKmTMB[i])
                {
                    MaxTavolsag = FuvarHosszKmTMB[i];
                    MaxNEv = NevekTMB[i];
                }
            }
            Console.WriteLine("Legnagyobb távolság: {0} \nLegnagyobb tavolságot ez a személy tette meg: {1}", MaxTavolsag, MaxNEv);
            Console.WriteLine("Legkisebb távolság: {0} \nLegkisebb tavolságot ez a személy tette meg: {1}", MinTavolsag, MinNev);
            double MaxMinAtlag = (double)(MaxTavolsag + MinTavolsag) / 2;
            Console.WriteLine("A legkisebb, legnagyobb távolság átlaga: {0:0.00}", MaxMinAtlag);
        }

        private static void Feladat2Elszamolas()
        {
            Console.WriteLine("2.Feladat: Elszamolas");
            int Elszamolas=0;
            for (int i = 0; i < NevekTMB.Length; i++)
            {
                Elszamolas = FuvarHosszKmTMB[i] * 11 + FuvaridoTMB[i] * 3 - KoltsegTMB[i] * 2 + BorravaloTMB[i];
                ElszamolasTMB[i] = Elszamolas;
            }
            for (int i = 0; i < NevekTMB.Length; i++)
            {
                Console.WriteLine("{0,-25} : {1}", NevekTMB[i], ElszamolasTMB[i]);
            }
        }

        private static void Feladat1Kiiratas()
        {
            Console.WriteLine("1.Feladat: Kiíratás");
            for (int i = 0; i < NevekTMB.Length; i++)
            {
                Console.WriteLine("{0,-25} -> {1:000} --> {2:00} ---> {3:00} ---->{4}", NevekTMB[i], FuvarHosszKmTMB[i], FuvaridoTMB[i],KoltsegTMB[i],BorravaloTMB[i]);
            }
        }

        private static void Feladat0AdatokFeltolt()
        {
            Console.WriteLine("0.Feladat: feltöltés");
            NevekTMB = new string[21] { "Zephaniah Harrington", "Akash Nava", "Jack Santiago", "Igor Hawkins", "Lennon Solomon", "Rafi Bradford", "Darcey Buckner", " Joey Faulkner", "Edgar O'Moore", "Santino Shea", "Jawad Orr", "Usmaan Conner", "Harlee Moyer", "Dean Whittington", "Graham Case", "Hamaad Graves", "Edwin Ayala", "Korey Franco", "Onur Bauer", "Taine Heath", "Kieren Wynn" };
            FuvarHosszKmTMB = new int[21] { 18, 37, 18, 41, 47, 34, 45, 21, 49, 15, 47, 19, 11, 32, 13, 44, 20, 19, 23, 44, 35 };
            FuvaridoTMB = new int[21] { 23, 22, 7, 17, 18, 18, 7, 16, 5, 8, 8, 10, 22, 22, 11, 9, 15, 5, 23, 14, 14 };
            KoltsegTMB = new int[21] { 50, 53, 55, 65, 51, 52, 60, 68, 66, 54, 61, 72, 58, 70, 64, 72, 53, 56, 65, 57, 64 };
            BorravaloTMB = new int[21] { 16, 20, 20, 12, 23, 18, 17, 20, 21, 17, 21, 23, 20, 15, 14, 23, 20, 21, 23, 19, 15 };

        }
    }
}
