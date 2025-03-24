using Economie25_101.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economie25_101.ClassesUtilitaires
{
    internal class GestionnaireBD
    {
        public static void DechargerListeEntreprises()
        {
            U.Titre("Écriture en BD de la liste des entreprises");
            StreamWriter sw = new StreamWriter(U.FICHIER_ENTREPRISE);
            if (Program.Producteurs is null)
            {
                return;
            }
            foreach(Entreprise e in Program.Producteurs)
            {
                sw.WriteLine($"{e.Id};{e.RaisonSociale};{e.Domaine};{e.AnneeFondation}");
            }
            sw.Close();
            U.P($"{Program.Producteurs.Count} entreprise sauvegardées en BD");
        }
    }
}
