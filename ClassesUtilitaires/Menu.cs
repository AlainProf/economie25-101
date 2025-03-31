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
        bool _top = true;

        public Menu(string n, bool top=true)
        {
            _nom = n;
            _options = new List<MenuItem>();
            _top = top;
        }

        public void AjouterOption(MenuItem o)
        {
            _options.Add(o);
        }

        public void Afficher(bool viderEcran = true)
        {
            U.Titre(_nom, _top);
            foreach (MenuItem o in _options)
            {
                U.WL("\t" + o.Cle + ": " + o.Item);
            }
            if (_top)
            {
                U.WL("\n\nEsc pour quitter");
            }
        }

        public void SaisirOption()
        {
            Afficher();
            ConsoleKeyInfo cle;
            while ( (cle=Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                foreach(MenuItem option in _options)
                {
                    if ((char)cle.Key == option.Cle)
                    {
                        if (_top)
                          U.CLS();
                        option.Execution();
                        if (_top)
                          Afficher();
                    }
                }
                if (!_top)
                    break;
            }
        }
    }
}
