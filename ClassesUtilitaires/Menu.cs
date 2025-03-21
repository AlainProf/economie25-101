using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie25_101.ClassesUtilitaires
{
    internal class Menu
    {
        string _nom;
        List<MenuItem> _options;

        public Menu(string n) {
            _nom = n;
            _options = new List<MenuItem>();
        }

        public void AjouterOption(MenuItem o)
        {
            _options.Add(o);
        }

        public void Afficher()
        {
            U.Titre(_nom);
            foreach (MenuItem o in _options)
            {
                U.WL("\t" + o.Cle + ": " + o.Item);
            }
            U.WL("\n\nEsc pour quitter");
        }

        public void SaisirOption()
        {
            ConsoleKeyInfo cle;
            while ( (cle=Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                foreach(MenuItem option in _options)
                {
                    if ((char)cle.Key == option.Cle)
                    {
                        U.CLS();
                        option.Execution();
                    }
                }
                Afficher();
            }
        }
    }
}
