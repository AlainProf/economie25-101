using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie25_101.Classes
{
    internal class Humain
    {
        // private string Nom;
        public string Nom { get; set; }
        public DateTime Naissance { get; set; }
        public string Sexe { get; set; }

        //------------------------------------------
        //
        //------------------------------------------
        public Humain()
        {
            //_u.Sep("In constructeur Humain()");
            Nom = "inconnu";
            Naissance = new DateTime(1, 1, 1);
            Sexe = "F";
        }
        //------------------------------------------
        //
        //------------------------------------------
        public Humain(string n)
        {
            Nom = n;
            Naissance = DateTime.Now;
            Sexe = "F";
        }
        //------------------------------------------
        //
        //------------------------------------------
        public Humain(string n, DateTime nais)
        {
            Nom = n;
            Naissance = nais;
            Sexe = "F";
        }
        //------------------------------------------
        //
        //------------------------------------------
        public Humain(string n, DateTime nais, string s)
        {
            Nom = n;
            Naissance = nais;
            Sexe = s;
        }


        //------------------------------------------
        //
        //------------------------------------------
        public static Humain HumainAleatoire()
        {
            string nom = "Adam";
            DateTime naissance = new DateTime(U.rdm.Next(1900, 2008), U.rdm.Next(1, 13), U.rdm.Next(1, 29));
            string numCiv = U.rdm.Next(100, 10000).ToString();
            string s = "M";
            if (U.rdm.Next(0, 2) == 0)
                s = "F";

            return new Humain(nom, naissance, s);
        }

        //------------------------------------------
        //
        //------------------------------------------
        public virtual void Afficher()
        {
            Console.Write($"{Nom}, {Age()} ans ");
            //Domicile.Afficher();    
        }

        //------------------------------------------
        //
        //------------------------------------------
        public long Age()
        {
            long debut = Naissance.Ticks;
            long fin = DateTime.Now.Ticks;
            return (fin - debut) / (10000000 * (long)365.24 * 86400);
        }

        //------------------------------------------
        //
        //------------------------------------------
        public static int ComparerNom(Humain a, Humain b)
        {
            return a.Nom.CompareTo(b.Nom);

        }

        //------------------------------------------
        //
        //------------------------------------------
        public static int ComparerAge(Humain a, Humain b)
        {
            if (a.Naissance.Ticks < b.Naissance.Ticks)
                return 1;
            if (a.Naissance.Ticks > b.Naissance.Ticks)
                return -1;
            return 0;
        }

    }
}
