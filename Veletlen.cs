using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StatikusOsztalyokOOP
{
    internal static class Veletlen      //Ha egy osztály statikus akkor csak statikus adattagjai és metódusai lehetnek
    {
        //private string abc;
        private static Random RND = new Random();
        private static List<string> VEZETEKNEVEK = Feltolt("database/veznev.txt");
        private static List<string> NOI_KERNEVEK = Feltolt("database/ferfikernev.txt");
        private static List<string> FERFI_KERNEVEK = Feltolt("database/noikernev.txt");
        private static List<string> SPORTAG = Feltolt("database/sportag.txt");
        private static List<string> EGYESULET = Feltolt("database/egyesulet.txt");

        public enum NEM
        {
            FERFI,
            NO
        }

        public enum SZOLG
        {
            HUSZ=20,
            HARMINC=30,
            HETVEN=70
        }
        

        private static List<string> Feltolt(string faljnev)
        {

            var list = new List<string>();
            using (StreamReader sr = new StreamReader(faljnev))         //érdemes a usingot itt használni, mert akkor automatikusan bezárja a streamreadert, nem kell a .Close()
            {
                while (!sr.EndOfStream) 
                {
                    string line = sr.ReadLine();
                    list.Add(line);
                }
            }
            return list;
            return File.ReadLines(faljnev).ToList();            //Ez a sor  ugyanazt csinálja mint 25-37 sor, szóval egyszerűbb
        }
        public static int VelEgesz(int min, int max)
        {

            return RND.Next(min, max+1);
        }

        public static char VelKarakter(char min, char max)       //A karaktereket intként tárolja az IDE. pl char a = 97, 
        {
            return (char)VelEgesz(min,max);
        }

        private static string VelFerfiKeresztNev()
        {
            return FERFI_KERNEVEK[RND.Next(FERFI_KERNEVEK.Count)];
        }
        private static string VelNoiKeresztNev()
        {
            return NOI_KERNEVEK[RND.Next(NOI_KERNEVEK.Count)];
        }

        public static string VelVezetekNev()
        {
            return VEZETEKNEVEK[RND.Next(VEZETEKNEVEK.Count)];
        }
        public static string VelKeresztNev(NEM nem)
        {
            switch(nem) 
            {
                case NEM.FERFI:
                    return VelFerfiKeresztNev();
                case NEM.NO:
                    return VelNoiKeresztNev();
                default: return "VALAMI NEM JÓ";
            }
        }
        public static string VelTeljesNev(NEM nem)
        {
            return VelVezetekNev() + " " + VelKeresztNev(nem);
        }

        public static string VelDatum(int ev1, int ev2)
        {   
                int ev = VelEgesz(ev1, ev2);
                int honap = VelEgesz(1, 12);
                int maxNap = (honap == 2 && DateTime.IsLeapYear(ev)) ? 29 : DateTime.DaysInMonth(ev, honap); //We can write condition in a variable
                int nap = VelEgesz(1, maxNap);
           // Console.WriteLine($"{ev}-{honap}-{nap}");
            return $"{ev}-{honap}-{nap}";
        }

        public static string velEmail(string nev)
        {       //Ékezet levétel
            string normalized = nev.Normalize(NormalizationForm.FormD);
            string pattern = @"[^\x20-\x7E]";
            string result = Regex.Replace(normalized, pattern, "").ToLower();
            return $"{result.Replace(" ", "")}{VelEgesz(1,100)}@gmail.com";   //replace all the spaces in a string with an empty string
        }

        public static string velMobil()
        {
            Array array = Enum.GetValues(typeof(SZOLG));
            array.GetValue(RND.Next(array.Length));
            return $"+36 (30) {VelEgesz(100, 999)}-{VelEgesz(10, 99)}-{VelEgesz(10,99)}";
        }

        public static string velSportag()
        {
            return SPORTAG[VelEgesz(0, SPORTAG.Count)];
        }

        public static string velSportegyesulet()
        {
            return $"{EGYESULET[VelEgesz(0, EGYESULET.Count)]} - {velSportag()}";
        }
    }
}
