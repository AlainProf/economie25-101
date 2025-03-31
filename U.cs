using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie25_101
{
    internal class U
    {
        public const string FICHIER_ENTREPRISE = @"d:\alino\atelier\economie\entreprises.txt";
        public const string FICHIER_EMPLOYES   = @"d:\alino\atelier\economie\employes.txt";
        public static Random rdm = new Random();
        public static void Titre(string texte, bool viderEcran = true)
        {
            if (viderEcran)
                CLS();
            foreach (char c in texte)
            {
                W("-");
            }
            WL("\n" + texte);
            foreach (char c in texte)
            {
                W("-");
            }
            WL("\n");
        }
        
        public static void WL(string texte = "")
        {
            Console.WriteLine(texte);   
        }

        public static void Sep(string texte = "")
        {
            WL(texte);
            foreach (char c in texte)
            {
                W("-");
            }
            WL("\n");
        }

    

        public static void W(string texte)
        {
            Console.Write(texte);  
        }

        public static void CLS()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
        }

        public static void P(string msg="")
        {
            if (msg.Length > 0)
            {
                WL(msg);
            }
            WL("\nAppuyez sur une touche...");
            Console.ReadKey(true);
        }

        public static string? RL()
        {
            return Console.ReadLine();
        }
        public static char RC()
        {
            ConsoleKeyInfo cle;
            cle = Console.ReadKey(true);
            return cle.KeyChar;
        }
    }
}
