using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie25_101
{
    internal class U
    {

        public static Random rdm = new Random();
        public static void Titre(string texte)
        {
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
        
        public static void WL(string texte)
        {
            Console.WriteLine(texte);   
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
    }
}
